﻿/*

	This file is part of SEOMacroscope.

	Copyright 2019 Jason Holland.

	The GitHub repository may be found at:

		https://github.com/nazuke/SEOMacroscope

	SEOMacroscope is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	SEOMacroscope is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with SEOMacroscope.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SEOMacroscope
{

  public partial class MacroscopeDocument : Macroscope
  {

    /**************************************************************************/

    private void ConfigureVideoPageRequestHeadersCallback ( HttpRequestMessage Request )
    {
      this.AuthenticateRequest( Request: Request );
    }

    /** -------------------------------------------------------------------- **/

    private async Task ProcessVideoPage ()
    {

      Stopwatch TimeDuration = new Stopwatch();
      long FinalDuration;

      TimeDuration.Start();

      try
      {
        await this._ProcessVideoPage();
      }
      catch ( Exception ex )
      {
        this.DebugMsg( string.Format( "ProcessVideoPage :: Exception: {0}", ex.Message ) );
      }

      TimeDuration.Stop();

      FinalDuration = TimeDuration.ElapsedMilliseconds;

      if ( FinalDuration > 0 )
      {
        this.Duration = FinalDuration;
      }
      else
      {
        this.Duration = 0;
      }

    }

    /** -------------------------------------------------------------------- **/

    private async Task _ProcessVideoPage ()
    {

      MacroscopeHttpTwoClient Client = this.DocCollection.GetJobMaster().GetHttpClient();
      MacroscopeHttpTwoClientResponse Response = null;
      string ResponseErrorCondition = null;

      try
      {

        Response = await Client.Get(
          this.GetUri(),
          this.ConfigureVideoPageRequestHeadersCallback,
          this.PostProcessRequestHttpHeadersCallback
        );

      }
      catch ( MacroscopeDocumentException ex )
      {
        this.DebugMsg( string.Format( "_ProcessVideoPage :: MacroscopeDocumentException: {0}", ex.Message ) );
        ResponseErrorCondition = ex.Message;
        this.SetStatusCode( HttpStatusCode.BadRequest );
        this.AddRemark( "_ProcessVideoPage", ex.Message );
      }
      catch ( Exception ex )
      {
        this.DebugMsg( string.Format( "_ProcessVideoPage :: Exception: {0}", ex.Message ) );
        ResponseErrorCondition = ex.Message;
        this.SetStatusCode( HttpStatusCode.BadRequest );
        this.AddRemark( "_ProcessVideoPage", ex.Message );
      }

      if ( Response != null )
      {

        this.ProcessResponseHttpHeaders( Response: Response );

        { // Title

          MatchCollection reMatches = Regex.Matches( this.DocUrl, "/([^/]+)$" );
          string DocumentTitle = null;

          foreach ( Match match in reMatches )
          {
            if ( match.Groups[ 1 ].Value.Length > 0 )
            {
              DocumentTitle = match.Groups[ 1 ].Value.ToString();
              break;
            }
          }

          if ( DocumentTitle != null )
          {
            this.SetTitle( DocumentTitle, MacroscopeConstants.TextProcessingMode.NO_PROCESSING );
            DebugMsg( string.Format( "TITLE: {0}", this.GetTitle() ) );
          }
          else
          {
            DebugMsg( string.Format( "TITLE: {0}", "MISSING" ) );
          }

        }

      }

      if ( ResponseErrorCondition != null )
      {
        this.ErrorCondition = ResponseErrorCondition;
      }

    }

    /**************************************************************************/

  }

}
