   M S B A M L   `   `   `  ����H  DScreenshotter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ScreenshotterScreenshotter  5   	       Screenshotter.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Screenshotter     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignPaper#���   5	   	     MaterialDesignBody#���  5
   	     � Title$  Screenshotter��5   	   $��290.667��6   $��333.333��60    � 
ResizeMode$ NoResize=�6@    � WindowStartupLocation$ CenterScreen=�6V   |�.   � Icon$2 ,pack://siteoforigin:,,,/Resources/camera.png��6�    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $k epack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.RadioButton.xaml?�6%   %    5      .��5      � .+�5   
   � $
��Left=�6   $	��252��6*   $��10,1,0,0q�67   $	��Top=�6I   $	��308��6a   .+�5      �� $��Salida��6     MaterialDesignGroupBox#���  6'   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6X   $��0q�6�   $
��Left=�6�   $	��100��6�   $��0,8,0,0q�6�   $	��Top=�6�   $	��299��6�   .��5      � $��	0,-3,0,13q�6   $	��284��6*   $��38��66   $��Bottom=�6B   .+�5      �� -   5         ��Name$ selectFolderBtn��5      $��Abrir��66   $
��Left=�6F   $��	199,0,0,2q�6a   $��75��6t   $��30��6�   $��Bottom=�6�   �� 5      -   5        	 ��Name$	 selectedFolderLabel��5      $��Selecciona una ruta.��69   $
��Left=�6X   $��10,0,0,4q�6s   $	��184��6�   
 � Cursor$

 Hand��6�   $��24��6�   $��Bottom=�6�   6�   5      5      �� 5      $��Hotkey��6   #���  6'   $ Depth3=�6X   $��0q�6�   $
��Left=�6�   $	��119��6�   $��	0,108,0,0q�6�   $	��Top=�6�   $	��299��6�   .��5      � $��0,0,0,-3q�6   $	��284��6)   $��66��65   $��Bottom=�6A   .+�5      d� -   5         d�Name$ 
modeToggle��5   #    * &MaterialDesignSwitchAccentToggleButton#��[ 67    � ToolTip$
 Modo��6w    d� 	IsChecked$
 TrueY�6�   $��20��6�   $��10,4,234,42q�6�   $��40��6�   6�   �� 5      -   5        $ singleKeyBtn��5      $��S��63   $
��Left=�6?   $��	10,29,0,0q�6Z   $	��Top=�6m   $
��10,0q�6�   6�   �� 5       -   5        $ ctrlKey_btn��5       $
��Ctrl��62   $
��Left=�6A   $��	10,29,0,0q�6\   $	��Top=�6o   $
��10,0q�6�   $y�Hidden=�6�   5#      5$      �� 5%      -   5        $	 
keyMessage��5%      $�� ��6(   $
��Left=�63   $��
10,230,0,0q�6N   $	��Top=�6b   $��0q�6z   $��10(�6�   d� 5&      -   5        $ soundToggle��5&       $  MaterialDesignActionToggleButton#��[ 60   $ Sonido��6j   $��	277,0,9,1q�6   $��22��6  $��22��6  $��Bottom=�6j  ��6{   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ AudioOff=�1  +MaterialDesignThemes.Wpf.ToggleButtonAssist   	OnContent 6�     $ Audio=�6j  5'      5(      5)      