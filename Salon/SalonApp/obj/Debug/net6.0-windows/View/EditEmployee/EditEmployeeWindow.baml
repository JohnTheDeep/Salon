   M S B A M L   `   `   `  ????C  ?SalonApp, Version=2.1.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SalonApp.View.EditEmployeeSalonApp.View.EditEmployee  5   	   3    -SalonApp.View.EditEmployee.EditEmployeeWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:SalonApp.View.EditEmployee     5   	     ? Title$/  )Добавление сотрудника??5   	   $	??625??6'   $	??690??64    ? 	Resources 5	       ?? 
TargetType ?? Property ?? Value ?? 
TargetType ??Name ?? Triggers P? Property	 P? Value
 ?? 
TargetName ?? CornerRadius   sys ?? Source(  "System.Windows.HorizontalAlignment&   System.Windows.VerticalAlignment??%i  '??       '?? ^    '?? ?    &	      '?? /    ?? 5   
   " ??6   .?5      ??  ? ??$ 17(?6)   ?? 5       ? ??$ 10q?6(   ?? 5       ? ??
 ???? 6,   ?? 5       ? ??$ 0q?60   ?? 5       ? ??$	 Top=?62   ?? 5       ? ??$	 180??6&   ?? 5       ? ??$
 Left=?64   ?? 5       ? ??
 ?????6+   ?? 5       ? ??
 ?????6+   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ? $??Panel??6   .+?5      ?? $ ContentSite??6/   $??Center=?5   %   $
??Left=?5    %   $??Header??5!   %   $??10,10,10,10q?5"   %   5#       5$      P? 5%       ?@??
IsSelected$
	 True??6<   . ?5&   "   ?? $
 Panel??6)    ? ?? ?#6096BA6R   5'      P? 5(       ?@??
IsSelected$	 False??6<   . ?5)   "   ?? $
 Panel??6)    ? ?? ?#274C776R   5*      P? 5+       ? {?$	 False??6;   . ?5,   "   ?? $
 Panel??6)    ? ?? ?#274C776R   ?? 5-   "   $
 Panel??6)    ? ??
 ?????6\   5.      50      53      ?? 54       ? ?? 55      ??56      Transparent??6)   58      59      ?? 5:   
   " ??6   .?5;      ??  ? ?? ?#6096BA6+   ?? 5<       ? ??
 ?????6+   ?? 5=       ? ??$ 0q?60   ?? 5>       ? ?? 5?      ?? 5@      " ??6&   .R?5A      ?? $ 2??6!   ???#6096BA._?5B      ?? $ contentPresenter??6/   #??z??6I   #??z??6}   $??Center=?6?   #??z??6?   $??Center=?6?   5C      5D      5F      5G      ?? 5H   
   " ??6   ?? 5I   
   $ Dictionary1.xaml??6)   ?? 5J   
   StandartListView??" ??6*   .?5K      ??  ? ?? 5L      ??5M      SkyBlue??6%   5O      ?? 5P       ? ?? 5Q      u?5R      0.5q?6%   5T      ?? 5U       ? ?? 5V      u?5W      2q?6#   5Y      ?? 5Z       ? ??$	 300??5]       5^      ?? 5_       ? ??$	 200??5b       5c      ?? 5d       ? ?? 5e       5f      
Center=?62   5h      ?? 5i       ? ?? 5j       5k      
Center=?60   5m      5n      5o      .??5p      ? $??5q?6    ? ColumnDefinitions 5q   
   ?? 5r      $
??193* ?6   ?? 5s      $
??630* ?6   .+?5u   
   ?? ???#E7ECEF$??0q?6*   $??0q?6>    ?? TabStripPlacement$
 Left=?6J   $??2??6c    5w      ??%?   '?       '?? N     ?? 5x      " ?6   .?5y      ??  ? ?? ?#274C7763   5z      ?? 5{      " ??6   .?5|      ??  ? ??$ Center=?6<   5}      5~      .@?5      ??  ?? 
IsSelected$
 True??6   $??0,0,0,0q?6*   ??5?      ?? 5?       ?? Orientation$ 
Horizontal=?6!   .+?5?      ?? $??0,0,5,0q?6    $??25??61   $??25??6<   $??/src/icons/home_512px.png??6I   ?? 5?      $??Bottom=?6$   $??Основное??6?   5?      .??5?      ? ???#E7ECEF.+?5?      ?? ???#E7ECEF$??1??62   $??5q?6B   $ 5??6M   ._?5?      ?? .+?5?      ? ???#E7ECEF.+?5?   "   ?? 
???????$	??Top=?6<   $
??Left=?6T   $??5q?6o   $	??150??6z   $	??150??6?   
???????$	??0.5q?6?   ._?5?   &   ?? $ Vertical=?61   .+?5?   *   ?? .+?5?   .   ?? $#??/src/icons/contacts_512px.png??64   5?   +   5?   '   5?   #   ?? 5?   "   $??15(?6Z   $??Center=?6h   $??5,170,323,399q?6?   $"??Высылать емейл???6?    d? 	IsChecked 6+   ??  ?? Path$ SelectedEmp.IsEmail?6?   ?? 5?   "   $
??Left=?6*   $ 5??6E   
???????$??	170,5,5,5q?6i   
???????$	??0.5q?6?   $	??300??6?   ._?5?   &   ?? $	??580??63   $ Vertical=?6@   $	??250??6W   .+?5?   *   ?? 
???   ?$??15(?6G   $??ФИО??6U   $??4q?6`   $??Center=?6k   ?? 5?   *   
???   ?$??15(?6d   $??4q?6s    ?? TextAlignment$ Center=?6~   ??6E   ?? $ FullName?6~   ?? 5?   *   
???   ?$??15(?6H   $??Должность??6V   $??4q?6g   $??Center=?6r   ?? 5?   *   
???   ? ?? DisplayMemberPath$ RankName??6?   $??15(?6?   $??4q?6?   ??6G   ?? $ Ranks? ?? SelectedItem 6j   ?? $ SelectedRank? ?? Mode$ TwoWay=?6?   ?? 5?   *   
???   ?$??15(?6H   $??E-mail??6V   $??4q?6d   $??Center=?6o   ?? 5?   *   
???   ?$??15(?6F   $??4q?6q   $ Center=?6|   ??6T   ?? $ Email?6|   ?? 5?   *   
???   ?$??15(?6H   $1??+% с пакетов(опционально)??6V   $??4q?6v   $??Center=?6?   ?? 5?   *   
???   ?$??15(?6F   $??4q?6t   $ Center=?6   ??6T   ?? $ Ppackage?6   ?? 5?   *   
???   ?$??15(?6H   $-??'% с допов(опционально)??6V   $??4q?6t   $??Center=?6   ?? 5?   *   
???   ?$??15(?6F   $??4q?6r   $ Center=?6}   ??6T   ?? $ Paddit?6}   ?? 5?   *   
???   ?$??15(?6H   $1??+% с фиктива(опционально)??6V   $??4q?6v   $??Center=?6?   ?? 5?   *   
???   ?$??15(?6F   $??4q?6t   $ Center=?6   ??6T   ?? $ Pfictive?6   ?? 5?   *   
???   ?$??15(?6H   $<??6% с ручной работы(опционально)??6V   $??4q?6|   $??Center=?6?   ?? 5?   *   
???   ?$??15(?6F   $??4q?6t   $ Center=?6   ??6T   ?? $ Phandjob?6   ?? 5?   *   
???   ?$??15(?6H   $,??&Порог минимальной ЗП??6V   $??4q?6r   $??Center=?6}   ?? 5?   *   
???   ?$??15(?6F   $??4q?6y   $ Center=?6?   ??6T   ?? $ EntryTreshold?6?   ?? 5?   *   
???   ?$??15(?6H   $F??@Ставка если ЗП в день меньше порога??6V   $??4q?6?   $??Center=?6?   ?? 5?   *   
???   ?$??15(?6F   $??4q?6o   $ Center=?6z   ??6T   ?? $	 Bid?6z   ?? 5?   *   $??4q?6O   $??Сохранить??6[   $??17(?6o   ??61   ?? $
 Save?6o   5?   '   5?   #   5?      5?      5?      5?      5?      ?? 5?      $
 True??6   $??0,0,0,0q?6*   ??5?      ?? 5?      $ 
Horizontal=?6!   .+?5?      ?? $??0,0,5,0q?6    $??25??61   $??25??6<   $??/src/icons/home_512px.png??6I   ?? 5?      $??Bottom=?6$   $??Услуги??6?   5?      .??5?      ? ???#E7ECEF 5?      ?? 5?      ?? 5?      $	??150 ?6+   .+?5?      ? 
???????$??10q?6.   .+?5?      &   System.Windows.Controls.DataGrid  $??10q?6T    6#   ?? $ SelectedEnrollment???6`   ?? $ SelectedEmp.Enrollments?   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5?   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6b      Header$ Услуга??6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   ?? $ Service.ServiceName?6l     5?   "   $ * 6V   $ Процент??6`    65   ?? $ Percent?6`   5?      5?      ?? 5?      $ 5??6   
???????$??1??6A   $??
0,10,10,10q?6Q   ._?5?      ?? $??2q?6%   .+?5?      ?? $??15(?6X   $??4q?6f   $??Добавить??6q   ??6%   ?? $ OpenAddServiceEmpCommand?6q   ?? 5?      $??15(?6Y   $??4q?6g   $ ??Редактировать??6r   ??6%   ?? $ OpenEditServiceEmpCommand?6r   ?? 5?      $??15(?6T   $??4q?6b   $??Удалить??6m   ??6%   ?? $ DeleteEmployeeService?6m   5?      5?      5?      5?      5?      5?      5?      