   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  /clr-namespace:GUI.ViewModelsGUI.ViewModels  'clr-namespace:GUI.Helper
GUI.Helper      GUI.Views.LoginView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:GUI.Views     /vmodelclr-namespace:GUI.ViewModels     )helpclr-namespace:GUI.Helper     $	��550��$	��790��  � DataContext  #   GUI.ViewModels.LoginViewModel   � 	Resources   GUI.Helper.ParamConverter   ParamConverter��%   &	          .��� 
�������.+��� $
��Left=�$��	10,10,0,0q�$	��Top=����� *Title+�� $��Login��$
��Left=�$��364,375,0,0q�$	��Top=�$��75������ *GoToMainCommand+ �� Mode$ OneWay=���`�  `� 	Converter# [  .1���  �� ElementName$ NameTextBox�� �� Path$
 Text��� $ SurnameTextBox��$
 Text��� $
��Left=�$��458,390,0,0q�$	��Top=�$	��275������ *Alert+�� $
��name��$
��Left=�$��298,230,0,0q�$	��Top=��� $��surname��$
��Left=�$��298,301,0,0q�$	��Top=��� -    ��Name$ SurnameTextBox��$
��Left=�$��23��$��298,332,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��208���� -   $ NameTextBox��$
��Left=�$��23��$��298,261,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��208���� $��Sign up��$
��Left=�$��364,459,0,0q�$	��Top=�$��75������ *GoToNewUserCommand+$ OneWay=��� $��Admin��$
��Left=�$��364,498,0,0q�$	��Top=�$��75������ *GoToMainCommandAdmin+$ OneWay=��� $��
CarRetnal_��$
��Left=�$��
311,98,0,0q�$	��Top=�$��36(��� $��application��$
��Left=�$��390,142,0,0q�$	��Top=�$��18(��� $��Jędrzej Szor��$
��Left=�$��651,487,0,0q�$	��Top=��� $��Antoni Forzpańczyk��$
��Left=�$��651,461,0,0q�$	��Top=�