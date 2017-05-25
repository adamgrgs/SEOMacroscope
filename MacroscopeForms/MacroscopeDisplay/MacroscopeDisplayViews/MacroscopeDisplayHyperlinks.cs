﻿/*

  This file is part of SEOMacroscope.

  Copyright 2017 Jason Holland.

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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SEOMacroscope
{

  /// <summary>
  /// Description of MacroscopeDisplayHyperlinks.
  /// </summary>

  public sealed class MacroscopeDisplayHyperlinks : MacroscopeDisplayListView
  {

    /**************************************************************************/

    private const int ColUrl = 0;
    private const int ColUrlTarget = 1;
    private const int ColDoFollow = 2;
    private const int ColLinkTarget = 3;
    private const int ColLinkTextLabel = 4;
    private const int ColLinkTitleLabel = 5;
    private const int ColAltTextLabel = 6;

    private ToolStripLabel UrlCount;

    /**************************************************************************/

    public MacroscopeDisplayHyperlinks ( MacroscopeMainForm MainForm, ListView TargetListView )
      : base( MainForm, TargetListView )
    {
      
      this.SuppressDebugMsg = false;

      this.MainForm = MainForm;
      this.DisplayListView = TargetListView;
      this.UrlCount = this.MainForm.macroscopeOverviewTabPanelInstance.toolStripLabelHyperlinksUrls;
      
      if( this.MainForm.InvokeRequired )
      {
        this.MainForm.Invoke(
          new MethodInvoker (
            delegate
            {
              this.ConfigureListView();
            }
          )
        );
      }
      else
      {
        this.ConfigureListView();
      }

    }

    /**************************************************************************/

    protected override void ConfigureListView ()
    {
      if( !this.ListViewConfigured )
      {
        this.ListViewConfigured = true;
      }
    }

    /**************************************************************************/
    
    public new void ClearData ()
    {
      if( this.MainForm.InvokeRequired )
      {
        this.MainForm.Invoke(
          new MethodInvoker (
            delegate
            {
              this.DisplayListView.Items.Clear();
              this.RenderUrlCount();
            }
          )
        );
      }
      else
      {
        this.DisplayListView.Items.Clear();
        this.RenderUrlCount();
      }
    }

    /**************************************************************************/

    public void RefreshDataSearchSourceUrls (
      MacroscopeDocumentCollection DocCollection,
      string UrlFragment
    )
    {

      if( DocCollection.CountDocuments() <= 0 )
      {
        return;
      }

      if( this.MainForm.InvokeRequired )
      {
        this.MainForm.Invoke(
          new MethodInvoker (
            delegate
            {
              Cursor.Current = Cursors.WaitCursor;
              this.RenderListViewSearchSourceUrls(
                DocCollection: DocCollection,
                UrlFragment: UrlFragment
              );
              this.RenderUrlCount();
              Cursor.Current = Cursors.Default;
            }
          )
        );
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        this.RenderListViewSearchSourceUrls(
          DocCollection: DocCollection,
          UrlFragment: UrlFragment
        );
        this.RenderUrlCount();
        Cursor.Current = Cursors.Default;
      }

    }

    /**************************************************************************/

    public void RefreshDataSearchTargetUrls (
      MacroscopeDocumentCollection DocCollection,
      string UrlFragment
    )
    {

      if( DocCollection.CountDocuments() <= 0 )
      {
        return;
      }

      if( this.MainForm.InvokeRequired )
      {
        this.MainForm.Invoke(
          new MethodInvoker (
            delegate
            {
              Cursor.Current = Cursors.WaitCursor;
              this.RenderListViewSearchTargetUrls(
                DocCollection: DocCollection,
                UrlFragment: UrlFragment
              );
              this.RenderUrlCount();
              Cursor.Current = Cursors.Default;
            }
          )
        );
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        this.RenderListViewSearchTargetUrls(
          DocCollection: DocCollection,
          UrlFragment: UrlFragment
        );
        this.RenderUrlCount();
        Cursor.Current = Cursors.Default;
      }

    }

    /**************************************************************************/

    public void RenderListViewSearchSourceUrls (
      MacroscopeDocumentCollection DocCollection,
      string UrlFragment
    )
    {

      List<ListViewItem> ListViewItems = new List<ListViewItem> ( DocCollection.CountDocuments() );
            
      foreach( MacroscopeDocument msDoc in DocCollection.IterateDocuments() )
      {

        string Url = msDoc.GetUrl();

        if( Url.IndexOf( UrlFragment, StringComparison.CurrentCulture ) >= 0 )
        {

          this.RenderListView(
            ListViewItems: ListViewItems,
            msDoc: msDoc,
            Url: Url
          );

        }

      }

      this.DisplayListView.Items.AddRange( ListViewItems.ToArray() );
     
    }

    /**************************************************************************/

    public void RenderListViewSearchTargetUrls (
      MacroscopeDocumentCollection DocCollection,
      string UrlFragment
    )
    {

      List<ListViewItem> ListViewItems = new List<ListViewItem> ( DocCollection.CountDocuments() );
            
      foreach( MacroscopeDocument msDoc in DocCollection.IterateDocuments() )
      {

        string Url = msDoc.GetUrl();

        if( msDoc != null )
        {
          this.RenderListViewSearchTargetUrls(
            ListViewItems: ListViewItems,
            msDoc: msDoc,
            Url: Url,
            UrlFragment: UrlFragment
          );
        }

      }
      
      this.DisplayListView.Items.AddRange( ListViewItems.ToArray() );
     
    }

    /**************************************************************************/

    protected override void RenderListView (
      List<ListViewItem> ListViewItems,
      MacroscopeDocument msDoc,
      string Url
    )
    {
              
      MacroscopeAllowedHosts AllowedHosts = this.MainForm.GetJobMaster().GetAllowedHosts();
      MacroscopeHyperlinksOut HyperlinksOut = msDoc.GetHyperlinksOut();
      
      foreach( MacroscopeHyperlinkOut HyperlinkOut in HyperlinksOut.IterateLinks() )
      {

        ListViewItem lvItem = null;
        string UrlTarget = HyperlinkOut.GetTargetUrl();
        string PairKey = string.Join( "::", Url, UrlTarget );
        string LinkTarget = HyperlinkOut.GetLinkTarget();
        string LinkText = HyperlinkOut.GetLinkText();
        string LinkTitle = HyperlinkOut.GetLinkTitle();
        string AltText = HyperlinkOut.GetAltText();

        string LinkTextLabel = LinkText;
        string LinkTitleLabel = LinkTitle;
        string AltTextLabel = AltText;
        
        string DoFollow = "No Follow";

        if( HyperlinkOut.GetDoFollow() )
        {
          DoFollow = "Follow";
        }

        if( LinkText.Length == 0 )
        {
          LinkTextLabel = "MISSING";
        }
        
        if( LinkTitle.Length == 0 )
        {
          LinkTitleLabel = "MISSING";
        }
        
        if( AltText.Length == 0 )
        {
          AltTextLabel = "MISSING";
        }

        if( this.DisplayListView.Items.ContainsKey( PairKey ) )
        {

          try
          {

            lvItem = this.DisplayListView.Items[ PairKey ];

            lvItem.SubItems[ ColUrl ].Text = Url;
            lvItem.SubItems[ ColUrlTarget ].Text = UrlTarget;
            lvItem.SubItems[ ColDoFollow ].Text = DoFollow;
            lvItem.SubItems[ ColLinkTarget ].Text = LinkTarget;
            lvItem.SubItems[ ColLinkTextLabel ].Text = LinkTextLabel;
            lvItem.SubItems[ ColLinkTitleLabel ].Text = LinkTitleLabel;
            lvItem.SubItems[ ColAltTextLabel ].Text = AltTextLabel;

          }
          catch( Exception ex )
          {
            this.DebugMsg( string.Format( "MacroscopeDisplayLinks 1: {0}", ex.Message ) );
          }

        }
        else
        {

          try
          {

            lvItem = new ListViewItem ( PairKey );
            lvItem.UseItemStyleForSubItems = false;
            lvItem.Name = PairKey;

            lvItem.SubItems[ ColUrl ].Text = Url;
            lvItem.SubItems.Add( UrlTarget );
            lvItem.SubItems.Add( DoFollow );
            lvItem.SubItems.Add( LinkTarget );
            lvItem.SubItems.Add( LinkTextLabel );
            lvItem.SubItems.Add( LinkTitleLabel );
            lvItem.SubItems.Add( AltTextLabel );
                  
            ListViewItems.Add( lvItem );

          }
          catch( Exception ex )
          {
            this.DebugMsg( string.Format( "MacroscopeDisplayLinks 2: {0}", ex.Message ) );
          }

        }
        
        if( lvItem != null )
        {

          for( int i = 0 ; i < lvItem.SubItems.Count ; i++ )
          {
            lvItem.SubItems[ i ].ForeColor = Color.Blue;
          }

          if( AllowedHosts.IsAllowedFromUrl( Url ) )
          {
            lvItem.SubItems[ ColUrl ].ForeColor = Color.Green;
          }
          else
          {
            lvItem.SubItems[ ColUrl ].ForeColor = Color.Gray;
          }
          
          if( AllowedHosts.IsAllowedFromUrl( UrlTarget ) )
          {
            lvItem.SubItems[ ColUrlTarget ].ForeColor = Color.Green;
          }
          else
          {
            lvItem.SubItems[ ColUrlTarget ].ForeColor = Color.Gray;
          }

          if( AllowedHosts.IsAllowedFromUrl( Url ) )
          {
            if( HyperlinkOut.GetDoFollow() )
            {
              lvItem.SubItems[ ColDoFollow ].ForeColor = Color.Green;
            }
            else
            {
              lvItem.SubItems[ ColDoFollow ].ForeColor = Color.Red;
            }
          }
          else
          {
            lvItem.SubItems[ ColDoFollow ].ForeColor = Color.Gray;
          }

          if( LinkText.Length == 0 )
          {
            lvItem.SubItems[ ColLinkTextLabel ].ForeColor = Color.Gray;
          }
          
          if( LinkTitle.Length == 0 )
          {
            lvItem.SubItems[ ColLinkTitleLabel ].ForeColor = Color.Gray;
          }
          
          if( AltText.Length == 0 )
          {
            lvItem.SubItems[ ColAltTextLabel ].ForeColor = Color.Gray;
          }

          if(
            ( LinkText.Length == 0 )
            && ( LinkTitle.Length == 0 )
            && ( AltText.Length == 0 ) )
          {
            lvItem.SubItems[ ColLinkTextLabel ].ForeColor = Color.Red;
            lvItem.SubItems[ ColLinkTitleLabel ].ForeColor = Color.Red;
            lvItem.SubItems[ ColAltTextLabel ].ForeColor = Color.Red;
          }

        }
            
      }

    }

    /**************************************************************************/
    
    
    private void RenderListViewSearchTargetUrls (
      List<ListViewItem> ListViewItems,
      MacroscopeDocument msDoc,
      string Url,
      string UrlFragment
    )
    {

      MacroscopeAllowedHosts AllowedHosts = this.MainForm.GetJobMaster().GetAllowedHosts();
      MacroscopeHyperlinksOut HyperlinksOut = msDoc.GetHyperlinksOut();
      
      foreach( MacroscopeHyperlinkOut HyperlinkOut in HyperlinksOut.IterateLinks() )
      {

        string UrlTarget = HyperlinkOut.GetTargetUrl();
        string PairKey = string.Join( "::", Url, UrlTarget );
        string LinkTarget = HyperlinkOut.GetLinkTarget();
        string LinkText = HyperlinkOut.GetLinkText();
        string LinkTitle = HyperlinkOut.GetLinkTitle();
        string AltText = HyperlinkOut.GetAltText();

        string LinkTextLabel = LinkText;
        string LinkTitleLabel = LinkTitle;
        string AltTextLabel = AltText;
        
        string DoFollow = "No Follow";

        if( HyperlinkOut.GetDoFollow() )
        {
          DoFollow = "Follow";
        }
        
        if( LinkText.Length == 0 )
        {
          LinkTextLabel = "MISSING";
        }
        
        if( LinkTitle.Length == 0 )
        {
          LinkTitleLabel = "MISSING";
        }
        
        if( AltText.Length == 0 )
        {
          AltTextLabel = "MISSING";
        }
        
        if( 
          ( UrlTarget != null )
          && ( UrlTarget.IndexOf( UrlFragment, StringComparison.CurrentCulture ) >= 0 ) )
        {

          ListViewItem lvItem = null;

          if( this.DisplayListView.Items.ContainsKey( PairKey ) )
          {

            try
            {

              lvItem = this.DisplayListView.Items[ PairKey ];

              lvItem.SubItems[ ColUrl ].Text = Url;
              lvItem.SubItems[ ColUrlTarget ].Text = UrlTarget;
              lvItem.SubItems[ ColDoFollow ].Text = DoFollow;         
              lvItem.SubItems[ ColLinkTarget ].Text = LinkTarget;
              lvItem.SubItems[ ColLinkTextLabel ].Text = LinkTextLabel;
              lvItem.SubItems[ ColLinkTitleLabel ].Text = LinkTitleLabel;
              lvItem.SubItems[ ColAltTextLabel ].Text = AltTextLabel;

            }
            catch( Exception ex )
            {
              this.DebugMsg( string.Format( "MacroscopeDisplayLinks 1: {0}", ex.Message ) );
            }

          }
          else
          {

            try
            {

              lvItem = new ListViewItem ( PairKey );
              lvItem.UseItemStyleForSubItems = false;
              lvItem.Name = PairKey;

              lvItem.SubItems[ ColUrl ].Text = Url;
              lvItem.SubItems.Add( UrlTarget );
              lvItem.SubItems.Add( DoFollow );
              lvItem.SubItems.Add( LinkTarget );
              lvItem.SubItems.Add( LinkTextLabel );
              lvItem.SubItems.Add( LinkTitleLabel );
              lvItem.SubItems.Add( AltTextLabel );

              ListViewItems.Add( lvItem );

            }
            catch( Exception ex )
            {
              this.DebugMsg( string.Format( "MacroscopeDisplayLinks 2: {0}", ex.Message ) );
            }

          }
        
          if( lvItem != null )
          {

            for( int i = 0 ; i < lvItem.SubItems.Count ; i++ )
            {
              lvItem.SubItems[ i ].ForeColor = Color.Blue;
            }

            if( AllowedHosts.IsAllowedFromUrl( Url ) )
            {
              lvItem.SubItems[ ColUrl ].ForeColor = Color.Green;
            }
            else
            {
              lvItem.SubItems[ ColUrl ].ForeColor = Color.Gray;
            }
          
            if( AllowedHosts.IsAllowedFromUrl( UrlTarget ) )
            {
              lvItem.SubItems[ ColUrlTarget ].ForeColor = Color.Green;
            }
            else
            {
              lvItem.SubItems[ ColUrlTarget ].ForeColor = Color.Gray;
            }

            if( AllowedHosts.IsAllowedFromUrl( Url ) )
            {
              if( HyperlinkOut.GetDoFollow() )
              {
                lvItem.SubItems[ ColDoFollow ].ForeColor = Color.Green;
              }
              else
              {
                lvItem.SubItems[ ColDoFollow ].ForeColor = Color.Red;
              }
            }
            else
            {
              lvItem.SubItems[ ColDoFollow ].ForeColor = Color.Gray;
            }
            
            if( LinkText.Length == 0 )
            {
              lvItem.SubItems[ ColLinkTextLabel ].ForeColor = Color.Gray;
            }
          
            if( LinkTitle.Length == 0 )
            {
              lvItem.SubItems[ ColLinkTitleLabel ].ForeColor = Color.Gray;
            }
          
            if( AltText.Length == 0 )
            {
              lvItem.SubItems[ ColAltTextLabel ].ForeColor = Color.Gray;
            }

            if(
              ( LinkText.Length == 0 )
              && ( LinkTitle.Length == 0 )
              && ( AltText.Length == 0 ) )
            {
              lvItem.SubItems[ ColLinkTextLabel ].ForeColor = Color.Red;
              lvItem.SubItems[ ColLinkTitleLabel ].ForeColor = Color.Red;
              lvItem.SubItems[ ColAltTextLabel ].ForeColor = Color.Red;
            }

          }
          
        }
       
      }

    }

    /**************************************************************************/

    protected override void RenderUrlCount ()
    {
      this.UrlCount.Text = string.Format( "URLs: {0}", this.DisplayListView.Items.Count );
    }
     
    /**************************************************************************/

  }

}
