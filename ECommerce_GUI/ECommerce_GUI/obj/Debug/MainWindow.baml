   M S B A M L   `   `   `  ����H  DECommerce_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ECommerce_GUI.LoginECommerce_GUI.Login  5   	   -clr-namespace:ECommerce_GUIECommerce_GUI  5   	       ECommerce_GUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   /control!clr-namespace:ECommerce_GUI.Login  5   	   'localclr-namespace:ECommerce_GUI  5   	   -   5          � WindowStyle$
  None=�5
   	   $��1q�5   	   
���   � � AllowsTransparency .  � Title$ 
MainWindow��5   	   $��518.8��5   	   $	��800��5   	   .��5      � -   5        $��
mainCanvas��5      
�������.+�5   
   �� -   5        $
��test��5   6      welcomePage#��[  6   $
��Fill=�5      � 5   
    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      ]� $��1��6   .+�5      �� $	��Top=�6   $��30��5       �� Orientation$ 
Horizontal=�5      $��RightToLeft=�5       .+�5!      �� -   5        $��closeBtn��5'      
������ 
������ $��0q�5#      $��29��5$      $
��Auto��5%      $��	0,0,0,0.4q�5&      .��5)      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�62   
���   �$��22��5+   2   $��23��5,   2   5-      5.      5/      �� 50       �� CornerRadius$ 15��6   $��15q�51      $��1��52      
�������$��Bottom=�54      $��	0,0,0.2,0q�55      ._�56      � -   5         �Name$ 	loginArea��56      .+�57          ECommerce_GUI.Login.SignUp  -   5          Name$ 
signupCtrl��57   )       ECommerce_GUI.Login.SignIn  58      -   5        	  Name$	 
signinCtrl��58   )   59      5:      5;      5<      5=      5>      