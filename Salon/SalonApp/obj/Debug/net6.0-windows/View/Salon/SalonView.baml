   M S B A M L   `   `   `  ????C  ?SalonApp, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SalonApp.View.SalonSalonApp.View.Salon  5   	   #    SalonApp.View.Salon.SalonView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SalonApp.View.Salon     5   	     ? Title$  
Салон??5   	   $	??450??6   $	??800??6$   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5       ? RowDefinitions 5   
   ?? 5      $	??10* ?6   ?? 5      $
??100* ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??5q?6.   .+?5      ?? $??Салон: ??6   $??25(?6(   $
??Left=?66   $??Center=?6Q   $??0??6l   $??0??6y   ?? 5      $??25(?6F   $
??Left=?6T   $??Center=?6o   $??0??6?   $??0??6?   ??6   ??  ?? Path$ SelectedSalon.SalonName?6?   5      ? 5   
   $??5q?6   $??1??6   $??1??6'    5      ?? 5      $
??200* ?6#   ?? 5      $
??100* ?6#   .+?5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False??6B   $??0??6?   $??0??6?   $??5q?6?    ?? SelectedItem 6   ?? $ SelectedUser???6^   ?? $ Users?   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)   	   Header$	 
Логин??6U   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   ?? $ NickName?6U     5      $ * 6)   $	 ФИО??6b   
 63   ?? $ UserEmployee.FullName?6b     5      $ * 6)   $	 Тип??6U   
 63   ?? $ UserType?6U     5      $ * 6)   $	 Пароль??6U   
 63   ?? $ Password?6U   5!      ?? 5"      ???#E7ECEF$??0??6*   $??1??67   $??5q?6G    ?? CornerRadius$ 5??6R   ._?5#      ?? .+?5$      ?? $/??)Добавить пользователя??6O   $??15(?6o   $??25??6}   $	??Top=?6?   $??5q?6?   ??6   ?? $ OpenAddUserWindowCommand?6?   ?? 5%      $+??%Добавить сотрудника??6F   $??15(?6d   $??25??6r   $	??Top=?6~   $??5q?6?   ??6   ?? $ OpenAddEmployee?6?   ?? 5&      $)??#Добавить должность??6B   $??15(?6_   $??25??6m   $	??Top=?6y   $??5q?6?   ??6   ?? $ OpenAddRank?6?   ?? 5'      $9??3Редактировать пользователя??6P   $??15(?6u   $??25??6?   $	??Top=?6?   $??5q?6?   ??6   ?? $ OpenEditUserWindowCommand?6?   ?? 5(      $-??'Удалить пользователя??6H   $??15(?6g   $??25??6u   $	??Top=?6?   $??5q?6?   ??6   ?? $ DeleteUserCommand?6?   5)      5*      5+      5,      5-      