   M S B A M L   `   `   `  ����e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.1020.30, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  5   2   launcherQ6clr-namespace:Spellborn_Installer_v2;assembly=launcherSpellborn_Installer_v2 65   Spellborn_Installer_v2'   !Spellborn_Installer_v2.MainWindow   6	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      65   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6w   @d2http://schemas.microsoft.com/expression/blend/2008     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     62  Yspellborn_installer_v26clr-namespace:Spellborn_Installer_v2;assembly=launcher     65  -   5          � Title$!  The Chronicles of Spellborn��5   �  $��763.175��6�  $
��1354��6�   � 
ResizeMode$ NoResize=�6�   � WindowStartupLocation$ CenterScreen=�6�   � AllowsTransparency$
 True��6   � WindowStyle$
 None=�6"  ��6�  Z� ��6�  Z�  � 	Resources 5         ProgressBarControlTemplate1 �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard
 g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value �� Angle  FocusVisual J� SnapsToDevicePixels $  SystemColors.ControlTextBrushKey �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border 	 Button.Disabled.Background 
 Button.Disabled.Border  Button.Disabled.Foreground  ButtonStyle1 �� 
TargetType " SystemColors.HighlightBrushKey�� 5   
   %�  &	        &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 4    &		 W    &	
 z    &	 �    &	 �    7  7  7  7  7  7 	 7 
 7  �� 5      " �6B   .R�5      � $��TemplateRoot��6    5        5      CommonStates��. 5	        Determinate��6*     5
      Indeterminate��.	 5   "   �� $
 Forever��6-   .��5   &   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6D   $ 	Animation��6�   .\�5   *     $ 0��6?   $
 0.25Q�6K     5   *   $ 0:0:1��6?   $
 0.25Q�6O     5   *   $ 0:0:2��6?   $
 0.25Q�6O   5   '   *� 5   &   $' !(UIElement.RenderTransformOrigin)�6C   $ 	Animation��6�   .'�5   *     $ 0��6>   $ -0.5,0.5&�6J     5   *   $ 0:0:1��6>   $ 0.5,0.5&�6N     5   *   $ 0:0:2��6>   $ 1.5,0.5&�6N   5   '   5   #   5      5      .+�5      �� #��z��6   #��z��6I   #��z��6}   �� 5      $��
PART_Track��6    � 5      $��PART_Indicator��6   $
}�True��61   $
��Left=�6E   .+�5      �� $��	Indicator��6$   #��z��65   �� 5      $��	Animation��6$   #��z��65   $ 0.5,0.5&�6Y   z�5      V� 5    "   .~�5!   &   �� �� 5"   &   �� 5#   &   T� 5$   &   5%   #   5'      5(      5)       5*      P� 5+       �@�Orientation$ Vertical=�6A   . �5,      �� $ TemplateRoot��6!    �@�LayoutTransform 5-      �� 5.   "   $	 -90Q�62   50      51      P� 52       �@�IsIndeterminate$
 True��6E   . �53      �� $ 	Indicator��6!    � y�$ 	Collapsed=�6X   54      56      �� 57      .�58      ��  � �� 59      �� 5:      .R�5;      �� $��2q�6(   $
 True��63   #���  6N   $��1��6�   $	 1 2R�6�   5<      5>      5?      �� 5@      $ 	#FFDDDDDD��6?   �� 5A      $ 	#FF707070��6;   �� 5B      $ 	#FFBEE6FD��6B   �� 5C      $ 	#FF3C7FB1��6>   �� 5D      $ 	#FFC4E5F6��6@   �� 5E      $ 	#FF2C628B��6<   �� 5F      $ 	#FFF4F4F4��6A   �� 5G      $ 	#FFADB2B5��6=   �� 5H      $ 	#FF838383��6A   �� 5I      " ��6)   .�5J      ��  �@�FocusVisualStyle8   6F   �� 5K       � ��8  6/   �� 5L       � ��8  60   �� 5M       � ��# �  6/   �� 5N       � ��$ 1q�64   �� 5O       � ��$ Center=�6?   �� 5P       � ��$ Center=�6=   �� 5Q       � ��$ 1q�6,   �� 5R       � �� 5S      �� 5T      " ��6*   .R�5U      �� $��border��6%   #��z��63   #��z��6_   #��z��6�   $
 True��6�   ._�5V   "   �� $��contentPresenter��63   $|�False��6K   #��z��6]   #��z��6�   $
��True��6�   # z 6�   #��z��6  5W       5X      P� 5Y   "    �@��IsDefaulted$
 True��6H   . �5Z   &   �� $ border��6-   # �  6A    � ��6z   5[   #   P� 5\   "    � ��$
 True��6?   . �5]   &   �� $ border��6-   8   � ��6^   �� 5^   &   $ border��6-   8   � ��6_   5_   #   P� 5`   "    � {�$ False��6?   . �5a   &   �� $ border��6-   8   � ��6^   �� 5b   &   $ border��6-   8   � ��6_   �� 5c   &   $ contentPresenter��6-   8   � ��6m   5d   #   5f      5h      5i      5j      .��5l      � .+�5m   
   �� .+�5n      �� $	��663��6   $ ��/splborn_uirwrkartback.png��6!    �� Left$ 14��6E   
 �� Top$ 45��6V    K� ZIndex$ -1��6f   $��UniformToFill=�6x     �� StretchDirection$  UpOnly=�6�   $
��1330��6�   �� 5o      -   5        $��versionLabel��5o      $��Currently installed:��6(   $	 879��6G   $	 620��6Y   $	��162��6j   $��32��6v   $��Normal"�6�   
���������6�   Z� �� 5p      -   5        ! ��Name$! lbl_installedVersion��5p      $	 980��62   $	 652��6D   $
��Bold"�6U   $��61��6g   $��26��6r   
���������6�   Z� ]� 5q      �� 5r      -   5        $��
contentBox��5r      $	��474��6+   $ 28��68   $	 118��6I   $
��1303��6Z   $y�Visible=�6g   ��6|   Z� ��6�   Z� ��6�   Z� ��5s      �� 5t      " ��6   .�5u      ��  � y�$ 	Collapsed=�67   5v      .@�5x      �� -   5        $��welcome��5x      $��Welcome��6)   .��5y      � $��Center=�6   $
��1000��68   $	��374��6E   $��Center=�6R   .+�5z      )   #Microsoft.Web.WebView2.Wpf.WebView2  -   5        $��browser��5z   '   $ 5��66   $��
-2,17,33,0q�6G   $
��Auto=�6[   $
��Auto=�6�   $y�Hidden=�6�   5{      5|      �� 5}      -   5        $��settings��5}      $��Settings��6*   .��5~      � $��Center=�6   $
��1000��68   $	��374��6E   $��Center=�6R   .+�5      �� .+�5�      �� $ 14��6(   $
��Wrap=�69   $ 30��6M   $��16��6]   $	��450��6i   $
��Bold"�6u   ���	#FFFFFFFF�� 6�   " � Language$" en-gb�6�   $M�GThis is still a work in progress, but this can help you resolve issues.��6�   6  � 5�      -   5        # �Name$# grStep11��5�   #   $	��351��65   $	 301��6B   $	 212��6T   $	��445��6e   5�      �� 5�      ���	#FF380D03$
��Left=�65   $	��105��6P   $��	10,53,0,0q�6]   ���	#FF000000$	��Top=�6�   $
��1000��6�   $ J� Opacity$	$ 0.5Q�6�   �� 5�      -	   5        % ��Name$% lbl_installLocationx��5�   $   $
��Wrap=�6B   $��11(�6V   $��19,263,53,84q�6d   $��Consolas)�6z   $
��Bold"�6�   ���	#FFFFFFFF6�   �� 5�      -
   5        $% lbl_downloadProgressx��5�   $   $
��Wrap=�6C   $��8(�6W   $��723,474,258,245q�6d   �� 5�      -   5        & ��Name$& btn_ForceRedownload��5�   !   $��Force redownload��6>   $��14(�6Y   $ 5��6g   $��22,115,50,225q�6x   $
��Bold"�6�   6�   �� 5�      $
��Wrap=�6$   $ 5��68   $��16,60,29,291q�6I   $��14(�6_   $
��Bold"�6m   ���	#FFDADADA$	��957��6�   �� 6�   $" en-gb�6�   $%�Force re-download of game files��6�   �� 6�   �� 6�   �� 6�   �� 6  6  �� 5�      $
��Wrap=�6$   $��16,80,56,259q�68   ���	#FFBBBBBB$
��Bold"�6e   $��11(�6w   �� 6�   $X�RThis will reset the currently installed version and will force a full re-download.��6�   �� 6�   �� 6�   $�Re��6�   �� 6  $� ��6	  �� 6  $" en-gb�6  $%�quires restart of the launcher.��6)  �� 6S  �� 6`  6h  �� 5�      -   5        $& 	btnClosex��5�   !   $�� ��64   $��Center=�6?   $��
839,92,0,0q�6\   $��Center=�6p   ��6�   Z� ��6�   Z� ��6�   Z� �� 5�      ���	#FF380D03$
��Left=�65   $	��127��6P   $��
10,163,0,0q�6]   ���	#FF000000$	��Top=�6�   $
��1000��6�   $	$ 0.5Q�6�   �� 5�      $
��Wrap=�6$   $ 5��68   $��16,168,29,184q�6I   $��14(�6`   $
��Bold"�6n   ���	#FFDADADA�� 6�   $" en-gb�6�   $�Reset installation path��6�   6�   �� 5�      $
��Wrap=�6$   $��16,195,56,133q�68   ���	#FFBBBBBB$
��Bold"�6f   $��11(�6x   �� 6�   $���This will remove the installation path, after which the launcher allows you to pick a new location. Keep in mind that this will ��6�   �� 6  $� ��6  �� 6%  $Z�TNOT move the files and you will need to force redownload or move the files yourself.��6)  �� 6�  6�  �� 5�      -   5        $& btn_ResetinstallationPath��5�   !   $��Reset installation path��6D   $��14(�6f   $
��Bold"�6t   $��22,245,50,97q�6�   6�   �� 5�      -   5        $& btn_BackToMain��5�   !   $��X��69   $��22(�6E   $ 17��6S   $
��Bold"�6e   
���   �$��950,-4,0,294q�6�   $��20��6�   $��38��6�   ��6w   Z� ��6�   Z� 6�   �� 5�      ���	#FF380D03$
��Left=�65   $��55��6P   $��
10,300,0,0q�6\   ���	#FF000000$	��Top=�6�   $	��432��6�   $	$ 0.5Q�6�   �� 5�      $
��Wrap=�6$   $ 5��68   $��16,300,298,51q�6I   $��14(�6`   $
��Bold"�6n   ���	#FFDADADA�� 6�   $" en-gb�6�   $�Change game language��6�   �� 6�   �� 6�   �� 6�   �� 6�   6�   �� 5�      -   5        ' ��Name$' cbx_gameLanguage��5�   #   $
��Left=�6=   ( �� SelectedValuePath$( Content��6Y   $��184,251,6,-2q�6�   $	��250��6�   $��19��6�   ) �� IsDropDownOpen$
) True��6�   .@�5�      �� $��English��6+   �� 5�      $��German��6+   �� 5�      $��French��6+   �� 5�      $��Russian��6+   �� 5�      $��Korean��6+   �� 5�      $��Chinese��6+   5�      �� 5�      $
��Wrap=�6$   $��22,325,50,35q�68   ���	#FFBBBBBB$
��Bold"�6e   $��11(�6w   �� 6�   $" en-gb�6�   $J�DThe launcher needs to be launched as administrator for this to work.��6�   6�   5�      5�      �� 5�      -   5        $��install��5�      $��Install wizard��6)   .��5�      � $��Center=�6   $	��480��68   $	��374��6D   $��Center=�6Q   .+�5�      �� .+�5�      �� $ 22��6(   $
��Wrap=�69   $ 60��6M   $��16��6]   $	��436��6i   $
��Bold"�6u   �� 5�      $P�JIt looks like it's the first time you are running this launcher - welcome!��6   
�������6h   �� 5�      �� 5�      $L�FIn order to get started, we'll need to choose the installation folder.��6   �� 5�      �� 5�      5�      � 5�      -   5        $��grStep1��5�   #   $	��351��62   $	 301��6?   $	 212��6Q   $	��445��6b   �� 5�      -   5        $%��btn_confirmInstallationLocation��5�   %   $��Confirm install location��6L   $ 70��6o   $	 318��6�   $	��340��6�   $��14(�6�   $��27��6�   $
��Bold"�6�   ${�False��6�   ���	#FF0A0000
���   �6   �� 5�      $��46��6$   $ 31��60   $ 19��6A   $	��375��6Q   $!��Resources/welcome-title.png��6]   $
��Fill=�6�   �� 5�      ���	#FF380D03$��68��69   $ 10��6E   ���	#FF000000$	 243��6i   $	��421��6z   $	$ 0.7Q�6�   5�      �� 5�      ���	#FF380D03$
��Left=�65   $	��151��6P   $��9,81,0,0q�6]   ���	#FF000000$	��Top=�6�   $	��432��6�   $	$ 0.5Q�6�   �� 5�      $
��Wrap=�6$   $��11(�68   $��16,244,38,113q�6F   $ ��You have chosen this path:��6]   ���	#FFD3D3D36   �� 5�      -   5        $��lbl_installLocation��5�   $   $
��Wrap=�6?   $��11(�6S   $��19,263,53,84q�6a   $��Consolas)�6w   $
��Bold"�6�   ���	#FFFFFFFF6�   �� 5�      -   5        $��lbl_downloadProgress��5�   $   $
��Wrap=�6@   $��8(�6T   $��723,474,258,245q�6a   �� 5�      $
��Wrap=�6$   $��11(�68   $��16,287,59,70q�6F   $G��AIf this is correct, click the button below and we'll get started!��6\   ���	#FFFFFFFF6�   �� 5�      $
��Left=�6    $��29��6;   $��
783,90,0,0q�6G   $	��Top=�6[   $��95��6s   $!��Resources/minimizeclose.png��6~   �� 5�      -   5        $��btn_selectInstallDir��5�   !   $#��Select installation directory��6=   $��14(�6e   $ 5��6s   $��19,187,53,153q�6�   $
��Bold"�6�   6�   �� 5�      $
��Wrap=�6$   $ 5��68   $��19,83,26,268q�6I   $��14(�6_   $
��Bold"�6m   ���	#FFDADADA�� 5�      $<�6To continue, please select the installation directory.��6   �� 5�      �� 5�      �� 5�      �� 5�      5�      �� 5�      $
��Wrap=�6$   $��19,104,53,192q�68   ���	#FFBBBBBB$
��Bold"�6f   $��11(�6x   �� 5�      $���The Chronicles of Spellborn currently does not support installation to Program Files due to permission issues and the fact that the game is very old.��6   �� 5�      �� 5�      �� 5�      �� 5�      $-�'The folder 'The Chronicles of Spellborn��6    �� 5�      $�'��6    �� 5�      $%� will be created automatically.��6   �� 5�      �� 5�      $;�5Our suggestion is to use C:\Games or on another disk.��6   5�      �� 5�      -   5        $��btnClose��5�   !   $�� ��61   $
��Left=�6<   $��
839,92,0,0q�6W   $	��Top=�6k   $��31��6�   ��6�   Z� ��5�      �� 5�   "   $ 	#FFDDDDDD��62   * �� Opacity$* 0Q�6D   5�      5�      5�      �� 5�      $��Label��6   5�      �� 5�      -   5        $��btn_Settings��5�      $�� ��6)   $
 1208��64   $ 46��6G   $��32��6W   $��34��6b   $ 0.266,0.318&�6�   ��6n   Z� ��6�   Z� ��5�      �� 5�      + �� ImageSource$+ /cog.png��6!   5�      � 5�      -   5        , �Name$, progressBar��5�      $��58��6/   $ 28��6;   $	 620��6L   $	��846��6]   
����������	#FF0E0001- � Orientation$- Vertical=�6�   ��5�      �� 5�      . �� EndPoint$. 0.5,1&�6*   / �� 
StartPoint$/ 0.5,0&�6;   .��5�      � 0 � Color$0 	#FFD38D5F��6'   � 5�      $0 Black��6'   � 5�      $0 	#FFEC7F38��6'   1 � Offset$1 0Q�69   � 5�      $0 	#FFFDA369��6'   $1 0.987Q�69   � 5�      $0 	#FFDC8146��6'   $1 0.487Q�69   5�      5�      �� 5�      -   5        $& lbl_progressBar��5�      $��Button��6.   $
 1046��6?   $	 620��6R   
�������$��58��6�   $	��285��6�   
���   ���6�   Z� 6�   �� 5�      -   5        $& btnMinimize��5�      $��-��6*   $
 1245��66   $��34��6I   $��50��6U   
�������$ 46��6�   $��25(�6�   ��6`   Z� ��6v   Z� 6�   �� 5�      -   5        $& 	btnClose1��5�      $��X��6(   $
 1288��64   $��32��6G   $��48��6S   
�������$ 48��6�   $��20(�6�   $ 0.465,0.155&�6�   ��6q   Z� ��6�   Z� 6�   �� 5�      -   5        $! gamelabeltext��5�      $*��$The Chronicles Of Spellborn Launcher��6+   $ 28��6Z   $ 50��6k   
�������$��15(�6�   �� 5�      $��Launcher Version��6   $	 879��6/   $	 652��6A   
���������6e   Z� 5�      5�      5�      