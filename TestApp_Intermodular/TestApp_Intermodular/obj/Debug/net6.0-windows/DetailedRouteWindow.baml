   M S B A M L   `   `   `  ????O  KTestApp_Intermodular, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TestApp_IntermodularTestApp_Intermodular  5   	   .    (TestApp_Intermodular.DetailedRouteWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TestApp_Intermodular     5   	     ? Title$  DetailedRouteWindow??5   	   $	??250??6%   $	??600??62    ? 
ResizeMode$ NoResize=?6>    ? WindowStartupLocation$ CenterScreen=?6T    ? WindowStyle$
 None=?6y   ???#1A759F.??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   .+?5   
   ?? -   5         ??Name$ 
RouteImage??5      $	??290??5      $	??290??5      $??0??5      $??0??5      $	??Top=?5      $??5q?5      ?? 5   
   $??0??6    ?? Orientation$ 
Horizontal=?6%   $??Center=?6>   $??Bottom=?6[   $??0,0,0,50q?6v   .+?5      ?? -   5        $??Subir Imagen??5      $	??100??6J   $??25??6Y   $y?	Collapsed=?6e   ?? 5      -   5        $??Borrar Imagen??5      $	??100??6K   $??25??6Z   $??10,0,0,0q?6f   $y?	Collapsed=?6x   5      ?? 5#   
   $??1??6   .+?5$      ?  5%      ?? 5&      $??* ?6'   ?? 5'      $
??Auto ?6'   .+?5)      ?? -   5         ??Name$ RouteTitleTextBox??5)      $??Titulo de la ruta??5*      $??24(?5+      $??5,0,0,0q?5,      ?? 5-      -   5        $??1??5-      $??X??5.      $??Right=?5/      $??Center=?50      ???#34A0A4$??22??53      $??22??54      
???????$??14(?56      $??0,0,5,0q?57      58      ? 5:       5;      ?? 5<      $??* ?6'   ?? 5=      $
??Auto ?6'   .+?5?      ?? -   5        $ RouteDifficultyTextBox??5?      $??Dificultad de la ruta??5@      $??14(?5A      $
??Left=?5B      $??5,0,0,0q?5C      ?? 5D      -   5        $ RouteDistanceTextBox??5D      $??Km??5E      $??14(?5F      $??0,0,5,0q?5G      $??Right=?5H      5I      ?? 5K      -   5        $ RouteDescriptionTextBox??5K      
?????? $	??290??5M      $	??100??5N      ?? 5P      -	   5        $ CommentsTextBlock??5P      $??Comentarios de la ruta??5Q      $??14(?5R      $??5,0,0,0q?5S      $y?	Collapsed=?5T      ?? 5V      $
??Auto=?6   5W      ? 5Y      $??Bottom=?6    5Z      ?? 5[      $??* ?6'   ?? 5\      $
??Auto ?6'   .+?5^      ?? -
   5        $ RouteAuthorTextBox??5^      $??Autor??5_      $??14(?5`      $
??Left=?5a      $??5,0,0,0q?5b      5c      ?? 5d      -   5        	 ??Name$	 DeleteRouteButton??5d      $??Eliminar ruta??5e      $??70??5f      $??20??6   $??0,10,0,0q?5g      ???#52B69A$??Center=?5j      $y?	Collapsed=?5k      5l      5m      5n      