   M S B A M L   `   `   `  ???? C  ?SalonApp, Version=2.1.2.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SalonApp.View.DutyEditSalonApp.View.DutyEdit  .    (SalonApp.View.DutyEdit.EditJournalWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:SalonApp.View.DutyEdit     ???#E7ECEF$??bahnschrift)?  ? Title$"  Редактирование??$	??310??$	??900??.???? $??5q?.+?]? $
??Left=?$	??600??$??30??$??5,5,5,0q?.+??? 
??????? ?? CornerRadius$ 5??._??? $??10,2,2,2q? ?? Orientation$ 
Horizontal=?.+??? $??5,0,0,0q?$??17(?????  ?? Path$# SelectedJ.Service.ServiceName??? $ 
Horizontal=?.+??? $
??Left=?$??Имя мастера - ??$??17(??? $??5,0,0,0q?$??17(????? $! SelectedJ.Employee.FullName??? $??5,0,0,0q?$??;??$??17(??? $??1??$??5q?
???????$ 5??._??? $??5q?.+??? $ 
Horizontal=?.+??? $??5,29,5,5q?.+??? $
??Left=?$??2q?$??Имя Клиента??$??15(? ?? TextAlignment$ Center=??? $
??Left=?$	??200??$??15(????? $ SelectedJ.ClientName??? $??0,0,5,0q?$ Vertical=?.+??? $??Center=?$??2q?$)??#Основная процедура??$??15(?$ Center=??? $ 
Horizontal=?.+??? $??5q?.+??? $
??Left=?$??2q?$??Наличные??$??15(?$ Center=??? 
???????$
??Left=?$??80??$??15(????? $ SelectedJ.Cash??? $??5q?.+??? $
??Left=?$??2q?$??Безнал??$??15(?$ Center=??? 
???????$
??Left=?$??80??$??15(????? $ SelectedJ.NonCash??? $??5,0,0,0q?$ Vertical=?.+??? $??Ручная работа??$??2q?$??15(?$ Center=??? $ 
Horizontal=?.+??? $??5q?.+??? $??Center=?$??2q?$??Наличные??$??15(?$ Center=??? 
???????$??15(?$??80?????? $ SelectedJ.HandJobCash??? $??5q?.+??? $??Center=?$??2q?$??Безнал??$??15(?$ Center=??? 
???????$??15(?$??80?????? $ SelectedJ.HandJobNonCash??? $??5q?.+??? $
??Left=?$??
2,25.7,2,2q?$??Фиктив??$??15(?$ Center=??? 
????ح?$??80??$??15(????? $ SelectedJ.Fictive??? $??5q?.+??? $
??Left=?$??
2,25.7,2,2q?$??Сертификат??$??15(?$ Center=??? 
????·?$
??Left=?$??80??$??15(????? $ SelectedJ.Sertificate??? $??5q?.+??? $
??Left=?$??
2,25.7,2,2q?$??Перевод??$??15(?$ Center=??? 
?????_?$??80??
???????$??15(????? $ SelectedJ.Transfer??? $??0,5,0,0q?$ 
Horizontal=?.+??? $??210.5,0,5,0q?.+??? $??
Пакет??$??15(?$ Center=??? $	??260??$??15(????? $ SelectedJ.Package??? $ 
Horizontal=?.+??? $??5q?.+??? $??Center=?$
??Left=?$??Наличные??$??15(?$ Center=??? 
???????$
??Left=?$??15(?$??80?????? $ SelectedJ.PackageCash??? $??5q?.+??? $??Center=?$??Безнал??$??15(?$ Center=??? 
???????$??15(?$??80?????? $ SelectedJ.PackageNonCash??? $??5q?.+??? $??Center=?$??Перевод??$??15(?$ Center=??? 
?????_?$??15(?$??80?????? $ SelectedJ.PackageTransfer??? $??	4.7,0,0,0q?.+??? $??Допы??$??15(?$ Center=??? $	??170??${?False??$??15(??? $ 
Horizontal=?.+??? $??5q?.+??? $??Center=?$??Наличные??$??15(?$ Center=??? 
???????$??15(?$??80?????? $ SelectedJ.AdditCash??? $??5q?.+??? $??Безнал??$??15(?$ Center=??? 
???????$??Center=?$??15(?$??80?????? $ SelectedJ.AdditNonCash??? $	??150??$??Сохранить??$??17(?$??5q????? $
 Edit?