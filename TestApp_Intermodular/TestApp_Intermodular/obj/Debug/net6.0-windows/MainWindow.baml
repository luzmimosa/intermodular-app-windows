   M S B A M L   `   `   `  ????\  XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls  5   	   O KTestApp_Intermodular, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:TestApp_Intermodular.MVVM.ViewModel#TestApp_Intermodular.MVVM.ViewModel 5   	   ;"clr-namespace:TestApp_IntermodularTestApp_Intermodular 5   	   %   TestApp_Intermodular.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   [controlsDclr-namespace:System.Windows.Controls;assembly=PresentationFramework       5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   G	viewModel1clr-namespace:TestApp_Intermodular.MVVM.ViewModel      5   	   4local"clr-namespace:TestApp_Intermodular      5   	     ? Title$  
MainWindow??5
   	   $	??550??5   	   $	??920??5   	    ? WindowStyle$
 None=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? AllowsTransparency$
 True??5   	    ? WindowStartupLocation$ CenterScreen=?6#    ? DataContext 5      7 1TestApp_Intermodular.MVVM.ViewModel.MainViewModel  5   
   .??5      ?? ???#1A759F ?? CornerRadius$ 20??5      ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $	??200 ?6#   ?? 5       ? RowDefinitions 5      ?? 5      $??75 ?6    ?? 5      .+?5"      ?? $??1??6   $??2??5#      
???????5$      ?? 5&      $??WikiHonk??6   $??Bottom=?5'      $
??Left=?5(      $??	40,0,0,23q?5)      
???????$??22(?5+      ?? 5-      -   5        	 ??Name$	 welcome??5-      $??Bottom=?5.      $??Right=?5/      $??0,0,40,5q?50      
???????$??18(?52      $??0??53      $??1??54      ?? 56      $??1??6   .+?57      	? -   5        
 	?Name$
 Inicio??58      $??Inicio??57      $??50??59      
???   ?$??14(?5;      $y?Visible=?5<       d? 	IsChecked$
 TrueY?5=         MenuButtonTheme#??[  5>      ??5?      ?? *HomeViewCommand+	? 5A      -   5        $

 Mapa??5B      $
??Mapa??5A      $??50??5C      
???   ?$??14(?5E      $y?Visible=?5F      #??[  5G      ??5H      ?? *DiscoveryViewCommand+	? 5J      -   5        $
 Administrador??5J      $??Administrador??5K      $??50??5L      
???   ?$??14(?5N      $y?	Collapsed=?5O      #??[  5P      ??5Q      ?? *AdminViewCommand+	? 5S      -   5        $
 Perfil??5S      $??Perfil??5T      $??50??5U      
???   ?$??14(?5W      $y?Visible=?5X      #??[  5Y      ??5Z      ?? *ProfileViewCommand+	? 5\      -   5        $
 Salir??5\      $??Cerrar sesión??5]      $??50??5^      
???   ?$??14(?5`      $y?Visible=?5a      #??[  5c      5d      ?? 5f      -   5        $??-??5f      ???#168AAD$??22??5i      $??22??5j      $??1??5k      
???????$??12(?5m      $??Center=?5n      $	??Top=?5o      $??Right=?5p      $??0,5,45,0q?5q      ?? 5s      -   5        $??X??5s      $??Center=?5t      $??Center=?5u      ???#34A0A4$??22??5x      $??22??5y      $??1??5z      
???????$??14(?5|      $	??Top=?5}      $??Right=?5~      $??0,5,20,0q?5      ?? 5?      $??1??6   $??1??5?      $??10q?5?      ??5?      ?? *CurrentView+5?      5?      5?      