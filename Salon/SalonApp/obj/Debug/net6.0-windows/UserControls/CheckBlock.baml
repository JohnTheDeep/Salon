   M S B A M L   `   `   `  ????C  ?SalonApp, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Salon.UserControlsSalon.UserControls  5      #    Salon.UserControls.CheckBlock   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Salon.UserControls     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  6=   .??5	      ?? 
???????.+?5
   
   ?? $??5q?6   $??DemiBold"?6J   $??25(?6`   ??6    ??   ?? Path$  Service.ServiceName?6`   &   System.Windows.Controls.DataGrid  5   
      
IsReadOnly$
 true??6?      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6w      AutoGenerateColumns$ False??6?   $??5,15,5,5q?6?   $	??257??6?    ?? SelectedItem 6   ?? $  SelectedDuty???6Q   ?? $  Journals?*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ PreviewMouseDoubleClick??6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   ?? *
MBCCheck+5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width$
 * 6%      Header$ Мастер??6/   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6?   ?? $  Employee.FullName?  5      $
 * 6%   $ Наличка??6/    6@   ?? $  	TotalCash?  5      $
 * 6%   $ Безнал??6/    6?   ?? $  TotalNonCash?  5      $
 * 6%   $ Фиктив??6/    6?   ?? $  TotalFictive?  5      $
 * 6%   $ Сертификат??6/    6C   ?? $  TotalSertificates?5      ?? 5   
   $??5q?6   
???????$	??0.5q?6/   ._?5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $??2q?6   $??Bottom=?6(   $??12(?6C   $!??Итого наличка: ??6Q   ?? 5      $??2q?6   $??12(?6G   $
??Bold"?6U   ??6'   ?? $  	TotalCash?6U   ?? 5      $??2q?6   $??Bottom=?6(   $??12(?6C   $??Итого безнал: ??6Q   ?? 5      $??2q?6   $??12(?6J   $
??Bold"?6X   ??6'   ?? $  TotalNonCash?6X   ?? 5      $??2q?6   $??Bottom=?6(   $??12(?6C   $??Итого Фиктив: ??6Q   ?? 5       $??2q?6   $??12(?6J   $
??Bold"?6X   ??6'   ?? $  TotalFictive?6X   ?? 5!      $??2q?6   $??Bottom=?6(   $??12(?6C   $)??#Итого сертификаты: ??6Q   ?? 5"      $??2q?6   $??12(?6O   $
??Bold"?6]   ??6'   ?? $  AmountSertificate?6]   ?? 5#      $??2q?6   $??Bottom=?6(   $??12(?6C   $??Итого : ??6Q   ?? 5$      $??2q?6   $??12(?6F   $
??Bold"?6T   ??6'   ?? $  TotalSum?6T   5%      5&      5'      5(      