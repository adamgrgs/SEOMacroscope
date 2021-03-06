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
using HtmlAgilityPack;
using System.Xml.XPath;

namespace SEOMacroscope
{

  /// <summary>
  /// Description of MacroscopeDataExtractorXpaths.cs.
  /// </summary>

  [Serializable()]
  public class MacroscopeDataExtractorXpaths : MacroscopeDataExtractor
  {

    /**************************************************************************/

    private List<KeyValuePair<string, MacroscopeDataExtractorExpression>> ExtractXpaths;

    /**************************************************************************/
    
    public MacroscopeDataExtractorXpaths ( int Size )
      : base( Size: Size )
    {

      this.SuppressDebugMsg = true;
      
      this.ExtractXpaths = new List<KeyValuePair<string, MacroscopeDataExtractorExpression>> ( this.GetSize() );

      for( int Slot = 0 ; Slot < this.GetSize() ; Slot++ )
      {
        
        this.ExtractActiveInactive.Add( MacroscopeConstants.ActiveInactive.INACTIVE );
        
        MacroscopeDataExtractorExpression Expression;
          
        Expression = new MacroscopeDataExtractorExpression ( 
          NewLabel: "",
          NewExpression: "",
          NewExtractorType: MacroscopeConstants.DataExtractorType.INNERTEXT
        );

        this.ExtractXpaths.Add(
          new KeyValuePair<string, MacroscopeDataExtractorExpression> (
            string.Format( "XPathExpression {0}", Slot + 1 ),
            Expression
          )
        );

      }

    }

    /**************************************************************************/

    public void SetXpath (
      int Slot,
      string XpathLabel,
      string XpathString,
      MacroscopeConstants.DataExtractorType ExtractorType
    )
    {

      MacroscopeDataExtractorExpression DataExtractorXpathsExpression;
      KeyValuePair<string, MacroscopeDataExtractorExpression> ExpressionSlot;

      if( 
        ( !string.IsNullOrEmpty( XpathString ) )
        && ( SyntaxCheckXpath( XpathString: XpathString ) ) )
      {

        DataExtractorXpathsExpression = new MacroscopeDataExtractorExpression (
          NewLabel: XpathLabel,
          NewExpression: XpathString,
          NewExtractorType: ExtractorType
        );

        ExpressionSlot = new KeyValuePair<string, MacroscopeDataExtractorExpression> (
          XpathLabel,
          DataExtractorXpathsExpression
        );

        this.ExtractXpaths[ Slot ] = ExpressionSlot;
        
        this.SetEnabled();

      }

    }

    /**************************************************************************/
        
    public string GetLabel ( int Slot )
    {
      return( this.ExtractXpaths[ Slot ].Key );
    }
    
    /**************************************************************************/
        
    public string GetXpath ( int Slot )
    {

      string Expression = this.ExtractXpaths[ Slot ].Value.Expression;
      
      return( Expression );

    }
    
    /**************************************************************************/

    public MacroscopeConstants.DataExtractorType GetExtractorType ( int Slot )
    {

      MacroscopeConstants.DataExtractorType ExtractorType = this.ExtractXpaths[ Slot ].Value.ExtractorType;

      return( ExtractorType );

    }

    /**************************************************************************/

    public List<KeyValuePair<string, string>> AnalyzeHtml ( string Html )
    {

      List<KeyValuePair<string, string>> ResultList = null; 
      HtmlDocument HtmlDoc = new HtmlDocument ();

      HtmlDoc.LoadHtml( html: Html );

      try
      {
        ResultList = AnalyzeHtmlDoc( HtmlDoc: HtmlDoc );
      }
      catch( Exception ex )
      {
        this.DebugMsg( string.Format( "AnalyzeHtml: {0}", ex.Message ) );
      }

      return( ResultList );
          
    }

    /** -------------------------------------------------------------------- **/

    public List<KeyValuePair<string, string>> AnalyzeHtmlDoc ( HtmlDocument HtmlDoc )
    {

      List<KeyValuePair<string, string>> ResultList = new List<KeyValuePair<string, string>> ( 32 );

      if( this.IsEnabled() )
      {

        for( int Slot = 0 ; Slot < this.GetSize() ; Slot++ )
        {

          HtmlNodeCollection NodeSet;
          string Label = this.ExtractXpaths[ Slot ].Key;
          string Expression = this.ExtractXpaths[ Slot ].Value.Expression;
          MacroscopeConstants.DataExtractorType ExtractorType = this.ExtractXpaths[ Slot ].Value.ExtractorType;

          if( this.GetActiveInactive( Slot ).Equals( MacroscopeConstants.ActiveInactive.INACTIVE ) )
          {
            continue;
          }
          else
          if( !SyntaxCheckXpath( XpathString: Expression ) )
          {
            continue;
          }

          NodeSet = HtmlDoc.DocumentNode.SelectNodes( xpath: Expression );

          if( 
            ( NodeSet != null )
            && ( NodeSet.Count > 0 ) )
          {

            foreach( HtmlNode Node in NodeSet )
            {

              KeyValuePair<string, string> Pair;
              string Text;
              
              switch( ExtractorType )
              {
              
                case MacroscopeConstants.DataExtractorType.OUTERHTML:
                  Text = Node.OuterHtml;
                  Pair = new KeyValuePair<string, string> ( key: Label, value: Text );
                  ResultList.Add( item: Pair );
                  break;
                  
                case MacroscopeConstants.DataExtractorType.INNERHTML:
                  Text = Node.InnerHtml;
                  Pair = new KeyValuePair<string, string> ( key: Label, value: Text );
                  ResultList.Add( item: Pair );
                  break;

                case MacroscopeConstants.DataExtractorType.INNERTEXT:

                  Text = Node.InnerText;

                  if( MacroscopePreferencesManager.GetDataExtractorsCleanWhiteSpace() )
                  {
                    Text = this.CleanWhiteSpace( Text: Text );
                  }

                  Pair = new KeyValuePair<string, string> ( key: Label, value: Text );

                  ResultList.Add( item: Pair );

                  break;

                default:
                  break;

              }

            }

          }

        }

      }

      return( ResultList );

    }

    /**************************************************************************/
    
    public static bool SyntaxCheckXpath ( string XpathString )
    {
      
      bool IsValid = false;

      try
      {
        
        XPathExpression expression = XPathExpression.Compile( XpathString );

        IsValid = true;

      }
      catch( XPathException ex )
      {

        DebugMsgStatic( ex.Message );

        IsValid = false;
        
      }
      catch( Exception ex )
      {

        DebugMsgStatic( ex.Message );

        IsValid = false;
        
      }

      return( IsValid );

    }

    /**************************************************************************/

  }

}
