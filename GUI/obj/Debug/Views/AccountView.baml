   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  5      /clr-namespace:GUI.ControllerGUI.Controller  5      /clr-namespace:GUI.ViewModelsGUI.ViewModels  5      'clr-namespace:GUI.Helper
GUI.Helper  5	          GUI.Views.AccountView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Views     5      /configclr-namespace:GUI.Controller     5      /vmodelclr-namespace:GUI.ViewModels     5      )helpclr-namespace:GUI.Helper     5	      $	��550��5      $	��790��6     � 	Resources  5        GUI.Helper.ParamConverter   ParamConverter��%   &	          5   
   6   5       � DataContext 5      %   GUI.ViewModels.AccountViewModel  5   
   .��5      � 
�������.+�5   
   �� $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   ��6   �� *Title+6X   �� 5   
   $
��name��6   $
��Left=�6   $��281,323,0,0q�6:   $	��Top=�6O    J� RenderTransformOrigin$ 0.275,0.538&�6g   �� 5   
   -   5         ��Name$ nameTextBox��5      $
��Left=�6'   $��22��6B   $��329,327,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��200��6�   �� 5   
   $��surname��6   $
��Left=�6"   $��267,361,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $ surnameTextBox��5      $
��Left=�6*   $��22��6E   $��329,365,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��200��6�   �� 5   
   $��
licence no��6   $
��Left=�6%   $��261,397,0,0q�6@   $	��Top=�6U   �� 5   
   -   5        $ licNoTextBox��5      $
��Left=�6(   $��22��6C   $��329,401,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��200��6�   �� 5!   
   $	��age��6   $
��Left=�6   $��295,431,0,0q�69   $	��Top=�6N   �� 5"   
   -   5        $ 
ageTextBox��5"      $
��Left=�6&   $��22��6A   $��329,435,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��200��6�   �� 5$   
   $
��Edit��6   $
��Left=�6    $��454,475,0,0q�6;   $	��Top=�6P   $��75��6h   ��6s   �� *EditCommand+ �� Mode$ OneWay=���5%      `� 5&       `� 	Converter# [  6   .1�5'      ��  �� ElementName$ nameTextBox��6    �� Path$
 Text�68   �� 5(      $ surnameTextBox��6   $
 Text�6;   �� 5)      $ licNoTextBox��6   $
 Text�69   �� 5*      $ 
ageTextBox��6   $
 Text�67   5+      5-      �� 5.   
   $��Edit user information��6   $
��Left=�60   $��261,292,0,0q�6K   $	��Top=�6`   �� 50   
   $��Go back��6   $
��Left=�6#   $��
10,520,0,0q�6>   $	��Top=�6R   $��75��6j   ��6u   �� *GoToHomeCommand+$ OneWay=��� 51   
   $
��Left=�6*   $��329,502,0,0q�6E   $	��Top=�6Z   ��6   �� *Alert+6Z   �� 53   
   ���	#FFF4F4F5$
��Left=�6%   $	��206��6@   $��
234,56,0,0q�6M   
���   �$	��Top=�6p   $	��366��6�   �� 54   
   $��User information:��6   $
��Left=�6,   $��
261,63,0,0q�6G   $	��Top=�6[   �� 55   
   $��Name:��6   $
��Left=�6    $��267,125,0,0q�6;   $	��Top=�6P   �� 56   
   $��Surname:��6   $
��Left=�6#   $��267,156,0,0q�6>   $	��Top=�6S   �� 57   
   $��Licence no:��6   $
��Left=�6&   $��267,187,0,0q�6A   $	��Top=�6V   �� 58   
   $
��Age:��6   $
��Left=�6   $��267,221,0,0q�6:   $	��Top=�6O   �� 59   
   $��
Identifier��6   $
��Left=�6%   $��
267,94,0,0q�6@   $	��Top=�6T   �� 5:   
   $
��Left=�6G   $��
352,94,0,0q�6b   $	��Top=�6v   ��6   �� $# (config:CurrentUserConfig.Id)�6v   �� 5;   
   $
��Left=�6I   $��352,125,0,0q�6d   $	��Top=�6y   ��6   �� $% (config:CurrentUserConfig.Name)�6y   �� 5<   
   $
��Left=�6L   $��352,156,0,0q�6g   $	��Top=�6|   ��6   �� $( "(config:CurrentUserConfig.Surname)�6|   �� 5=   
   $
��Left=�6J   $��352,187,0,0q�6e   $	��Top=�6z   ��6   �� $&  (config:CurrentUserConfig.LicNo)�6z   �� 5>   
   $
��Left=�6H   $��352,221,0,0q�6c   $	��Top=�6x   ��6   �� $$ (config:CurrentUserConfig.Age)�6x   5@      5A      