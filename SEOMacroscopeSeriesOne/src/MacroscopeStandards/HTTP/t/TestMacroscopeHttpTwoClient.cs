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
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SEOMacroscope
{

  [TestFixture]
  public class TestMacroscopeHttpTwoClient : Macroscope
  {

    /**************************************************************************/

    [Test]
    public async Task TestHttpTwoClientHead ()
    {

      MacroscopeHttpTwoClient Client = new MacroscopeHttpTwoClient();
      List<Uri> UrlList = new List<Uri>();

      UrlList.Add( new Uri( "https://nazuke.github.io/" ) );
      UrlList.Add( new Uri( "https://nazuke.github.io/robots.txt" ) );

      foreach( Uri Url in UrlList )
      {

        this.DebugMsg( string.Format( "Url: {0}", Url ) );

        MacroscopeHttpTwoClientResponse ClientResponse = await Client.Head(
          Url: Url,
          PreProcessCustomRequestHeadersCallback: this.PreProcessHeadRequestHeadersCallback,
          PostProcessRequestHttpHeadersCallback: this.PostProcessRequestHttpHeadersCallback
        );

        HttpResponseMessage Response = ClientResponse.GetResponse();

        this.DebugMsg( string.Format( "Response.Version: {0}", Response.Version ) );

        Assert.AreEqual( 200, (int) Response.StatusCode );

      }

    }

    /**************************************************************************/

    [Test]
    public async Task TestHttpTwoClientGet ()
    {

      MacroscopeHttpTwoClient Client = new MacroscopeHttpTwoClient();
      List<Uri> UrlList = new List<Uri>();

      UrlList.Add( new Uri( "https://nazuke.github.io/robots.txt" ) );

      foreach( Uri Url in UrlList )
      {

        this.DebugMsg( string.Format( "Url: {0}", Url ) );

        MacroscopeHttpTwoClientResponse ClientResponse = await Client.Get(
          Url,
          this.PreProcessHeadRequestHeadersCallback,
          this.PostProcessRequestHttpHeadersCallback
        );

        HttpResponseMessage Response = ClientResponse.GetResponse();

        this.DebugMsg( string.Format( "Response.Version: {0}", Response.Version ) );

        Assert.AreEqual( 200, (int) Response.StatusCode );

        Assert.Greater( ClientResponse.GetContentAsString().Length, 0 );

      }

      return;

    }

    /**************************************************************************/

    private void PreProcessHeadRequestHeadersCallback ( HttpRequestMessage Request )
    {
      this.DebugMsg( "PreProcessHeadRequestHeadersCallback Called" );
    }

    private void PostProcessRequestHttpHeadersCallback ( HttpRequestMessage Request, HttpRequestHeaders DefaultRequestHeaders )
    {
      this.DebugMsg( "PreProcessHeadRequestHeadersCallback Called" );
    }

    /**************************************************************************/

  }

}
