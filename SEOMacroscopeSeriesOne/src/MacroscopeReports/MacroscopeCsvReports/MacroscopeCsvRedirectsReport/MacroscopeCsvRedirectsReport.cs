﻿/*

  This file is part of SEOMacroscope.

  Copyright 2019 Jason Holland.

  The GitHub repository may be found at:

    https://github.com/nazuke/SEOMacroscope

  Foobar is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Foobar is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.IO;
using CsvHelper;

namespace SEOMacroscope
{

  public partial class MacroscopeCsvRedirectsReport : MacroscopeCsvReports
  {

    /**************************************************************************/

    public enum OutputWorksheet
    {
      REDIRECTS_AUDIT = 0,
      REDIRECT_CHAINS = 1
    }

    /**************************************************************************/

    public MacroscopeCsvRedirectsReport ()
    {
    }

    /**************************************************************************/

    public void WriteCsv (
      MacroscopeJobMaster JobMaster,
      MacroscopeCsvRedirectsReport.OutputWorksheet SelectedOutputWorksheet,
      string OutputFilename
    )
    {

      try
      {

        using ( StreamWriter writer = File.CreateText( OutputFilename ) )
        {

          CsvWriter ws = new CsvWriter( writer );

          switch ( SelectedOutputWorksheet )
          {
            case MacroscopeCsvRedirectsReport.OutputWorksheet.REDIRECTS_AUDIT:
              this.BuildWorksheetPageRedirectsAudit( JobMaster, ws );
              break;
            case MacroscopeCsvRedirectsReport.OutputWorksheet.REDIRECT_CHAINS:
              this.BuildWorksheetPageRedirectChains( JobMaster, ws );
              break;
            default:
              break;
          }

        }

      }
      catch ( CsvHelperException )
      {
        MacroscopeSaveCsvFileException CannotSaveCsvFileException;
        CannotSaveCsvFileException = new MacroscopeSaveCsvFileException(
          string.Format( "Cannot write to CSV file at {0}", OutputFilename )
        );
        throw CannotSaveCsvFileException;
      }
      catch ( IOException )
      {
        MacroscopeSaveCsvFileException CannotSaveCsvFileException;
        CannotSaveCsvFileException = new MacroscopeSaveCsvFileException(
          string.Format( "Cannot write to CSV file at {0}", OutputFilename )
        );
        throw CannotSaveCsvFileException;
      }

    }

    /**************************************************************************/

  }

}
