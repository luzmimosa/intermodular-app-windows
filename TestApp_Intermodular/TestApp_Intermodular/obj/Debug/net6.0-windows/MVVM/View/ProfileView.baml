   M S B A M L   `   `   `  ????O  KTestApp_Intermodular, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:TestApp_Intermodular.MVVM.ViewTestApp_Intermodular.MVVM.View  5      0    *TestApp_Intermodular.MVVM.View.ProfileView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:TestApp_Intermodular.MVVM.View     5      
?????? .??5
      ?   ? ColumnDefinitions  5   
   ?? 5      $	??190 ?6   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   .+?5   
   ?? -   5         ??Name$ Image??5      $	??180??6   $	??170??6+   $??0??68   $??1??6H   $??1??6\   $??3,0,0,35q?6i   ?? 5   
   $??0??6   $??1??6%   $??Bottom=?62    ?? Orientation$ 
Horizontal=?6M   .+?5      ?? -   5        $??Cambiar Imagen??5      $	??100??6F   $??25??6U   ?? 5      -   5        $??Modificar Perfil??5      $	??100??6L   $??25??6[   $??5,0,0,0q?6g   5      ?? 5   
   -   5         ??Name$ 
SaveButton??5      $??Guardar??6%   $??55??67   $	??100??6X   $??25??6g   $??0,5,0,0q?6s   $??0??6?   $??2??6?   $	??Top=?6?   $??Center=?6?   $y?	Collapsed=?6?   ?? 5   
   $??3??6   $??0??6(   $??Información de usuario??65   $??24(?6S   $??Center=?6a   
???   ?6~   ?? 5    
   $??1??6   $??1??6%   .+?5!      ?? -   5         ??Name$ NameTextBlock??5!      $#??Aquí va el nombre de usuario??5"      
???   ?$??3??5$      $??22(?5%      ?? 5&      -   5         ??Name$ NameTextBox??5&      $??Center=?5'      $
??Left=?5(      $	??200??5)      $??5,10,0,0q?5*      $y?	Collapsed=?5+      ?? 5-      -   5        $ UserTextBlock??5-      $??Aquí va el usuario??5.      $??18(?5/      ?? 51      -   5        $ BioTextBlock??51      $??
Biografía??52      $??0,5,0,2q?53      $??18(?54      ?? 56      -	   5        $ BioDescriptionTextBlock??56      $#??Descripción de la biografía??57      $??0,5,0,2q?58      $
??Wrap=?59      $	??170??5:      $??16(?5;      ?? 5=      -
   5        $ BiographyTextBox??5=       ?? AcceptsReturn$
 True??5>       ?? TextWrapping$
 Wrap=?5?      "	 ?? VerticalScrollBarVisibility$
	 Auto=?5@      $	??170??5A      $y?	Collapsed=?5B      5C      5D      5E      