   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  5      /clr-namespace:GUI.ViewModelsGUI.ViewModels  5      'clr-namespace:GUI.Helper
GUI.Helper  5          GUI.Views.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:GUI.Views     5      /vmodelclr-namespace:GUI.ViewModels     5      )helpclr-namespace:GUI.Helper     5      $	��550��5
      $	��790��6     � DataContext  5      #   GUI.ViewModels.LoginViewModel  5   
    � 	Resources 5        GUI.Helper.ParamConverter   ParamConverter��%   &	          5   
   6   5      .��5      � 
�������.+�5   
   �� $
��Left=�6*   $��	10,10,0,0q�6E   $	��Top=�6X   ��6   �� *Title+6X   �� 5   
   $��Login��6   $
��Left=�6!   $��364,375,0,0q�6<   $	��Top=�6Q   $��75��6i   ��6t   �� *GoToMainCommand+ �� Mode$ OneWay=���5      `� 5       `� 	Converter# [  6   .1�5      ��  �� ElementName$ NameTextBox��6    �� Path$
 Text�68   �� 5      $ SurnameTextBox��6   $
 Text�6;   5      5      �� 5   
   $
��Left=�6*   $��458,390,0,0q�6E   $	��Top=�6Z   $	��275��6r   ��6   �� *Alert+6r   �� 5!   
   $
��name��6   $
��Left=�6   $��298,230,0,0q�6:   $	��Top=�6O   �� 5"   
   $��surname��6   $
��Left=�6"   $��298,301,0,0q�6=   $	��Top=�6R   �� 5$   
   -   5         ��Name$ SurnameTextBox��5$      $
��Left=�6*   $��23��6E   $��298,332,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��208��6�   �� 5%   
   -   5        $ NameTextBox��5%      $
��Left=�6'   $��23��6B   $��298,261,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��208��6�   �� 5'   
   $��Sign up��6   $
��Left=�6#   $��364,459,0,0q�6>   $	��Top=�6S   $��75��6k   ��6v   �� *GoToNewUserCommand+$ OneWay=��� 5(   
   $��Admin��6   $
��Left=�6!   $��364,498,0,0q�6<   $	��Top=�6Q   $��75��6i   ��6t   �� *GoToMainCommandAdmin+$ OneWay=��� 5*   
   $��
CarRental_��6   $
��Left=�6%   $��
311,98,0,0q�6@   $	��Top=�6T   $��36(�6l   �� 5+   
   $��application��6   $
��Left=�6&   $��390,142,0,0q�6A   $	��Top=�6V   $��18(�6n   �� 5-   
   $��Jędrzej Szor��6   $
��Left=�6'   $��651,487,0,0q�6B   $	��Top=�6W   �� 5.   
   $��Antoni Forzpańczyk��6   $
��Left=�6-   $��651,461,0,0q�6H   $	��Top=�6]   5/      50      