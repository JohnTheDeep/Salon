   M S B A M L   `   `   `  ???? C  ?SalonApp, Version=2.1.2.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:SalonApp.View.JournalViewSalonApp.View.JournalView  -    'SalonApp.View.JournalView.JournalWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:SalonApp.View.JournalView     ???#E7ECEF  ? Title$  Просмотр??$	??510??$	??780??.??? $??5q?$??bahnschrift)? ? ColumnDefinitions ?? $??* ? ? RowDefinitions ?? $??45 ??? ?? $	??125 ?.+??? 
??????? ?? CornerRadius$ 5??$??	10,5,10,5q?._???  ?? Orientation$ 
Horizontal=?.+??? $??5,0,0,0q?$??17(?$??Center=?????  ?? Path$ Service.ServiceName??? $??Right=?$??10,0,0,0q?$??17(????? $ Employee.FullName??? $??Right=?$??10,0,0,0q?$??17(????? $ Duty.DutyDate??? $??1??
???????$ 5??$??
10,0,10,10q?._?&   System.Windows.Controls.DataGrid  $??1??   AutoGenerateColumns$ False??$??
15,5,10,15q?$??Stretch=????? $ Journals?   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 	   Header$	 Имя клиента??1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 ?? $ 
ClientName?  $ * $	 Наличка??
 ?? $
 Cash?  $ * $	 Безнал??
 ?? $ NonCash?  $ * $	 Перевод??
 ?? $ Transfer?  $ * $	 Фиктив??
 ?? $ Fictive?  $ * $	 
Пакет??
 ?? $ Package?  $ * $ 	 Наличка(пакет)??
 ?? $ PackageCash?  $ * $	 Безнал(пакет)??
 ?? $ PackageNonCash?  $ * $	 Наличка(допы)??
 ?? $ 	AdditCash?  $ * $	 Бензал(допы)??
 ?? $ AdditNonCash?  $ * $/	 )Наличка(ручная работа)??
 ?? $ HandJobCash?  $ * $-	 'Безнал(ручная работа)??
 ?? $ HandJobNonCash?  $ * $	 Сертификат??
 ?? $ Sertificate?  $ * $	 
Итого??
 ?? $ Total?]? ???#E7ECEF$??2??$
??auto??$??Center=?$??Bottom=?$??0,0,0,0q?.+??? $ 5??
???????$??10q?$	??100??._?? $??5q?$??90??.+??? $
??auto??$
??Wrap=? ?? TextAlignment$ Center=?$??5,5,5,64q?$1??+Наличка за день (услуга)???? $??0,0,0,0q?$??Bottom=?$??50??.+??? $??25(?$ Center=?$??5q?$??Stretch=?$??40?????? $ 	TotalCash??? $ 5??
???????$??10q?$	??100??._?? $??5q?$??90??.+??? $
??Wrap=?$ Center=?$??5q?$/??)Безнал за день (услуга)???? $??0,10,0,0q?$??Bottom=?$??50??.+??? $??25(?$ Center=?$??5q?$??Stretch=?$??40?????? $ TotalNonCash??? $ 5??
???????$??10q?$	??100??._?? $??5q?$??90??.+??? $
??Wrap=?$ Center=?$??5q?$"??Наличка(пакеты)???? $??Bottom=?$??50??.+??? $??25(?$ Center=?$??5q?$??Stretch=?$??40?????? $ PackagesCahs??? $ 5??
???????$??10q?$	??100??._?? $??5q?$??90??.+??? $
??Wrap=?$ Center=?$??5q?$ ??Безнал(пакеты)???? $??Bottom=?$??50??.+??? $??25(?$ Center=?$??5q?$??Stretch=?$??40?????? $ PackagesNonCahs??? $ 5??
???????$??10q?$	??100??._?? $??5q?$??90??.+??? $
??Wrap=?$ Center=?$??5q?$*??$Сертификаты(услуга)???? $??Bottom=?$??50??.+??? $??25(?$ Center=?$??5q?$??Stretch=?$??40?????? $ Sertificates??? $ 5??
???????$??10q?$	??100??._?? $??5q?$??90??.+??? $
??Wrap=?$ Center=?$??5q?$7??1ЗП админу за пакеты(услуга)???? $??Bottom=?$??50??.+??? $??25(?$ Center=?$??5q?$??Stretch=?$??40?????? $ 
AdminTotal??? $ 5??
???????$??10q?$	??100??._?? $??5q?$??90??.+??? $
??Wrap=?$ Center=?$??5q?$6??0ЗП мастеру за день (услуга)???? $??Bottom=?$??50??.+??? $??25(?$ Center=?$??5q?$??Stretch=?$??40?????? $ 	EmplTotal?