   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GUI.Views	GUI.Views  /clr-namespace:GUI.ControllerGUI.Controller  /clr-namespace:GUI.ViewModelsGUI.ViewModels  'clr-namespace:GUI.Helper
GUI.Helper      GUI.Views.AccountView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:GUI.Views     /configclr-namespace:GUI.Controller     /vmodelclr-namespace:GUI.ViewModels     )helpclr-namespace:GUI.Helper       � 	Resources    GUI.Helper.ParamConverter   ParamConverter��%   &	           � DataContext %   GUI.ViewModels.AccountViewModel  .��� 
�������.+��� $
��Left=�$��	10,10,0,0q�$	��Top=����� *Title+�� $
��name��$
��Left=�$��281,193,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.275,0.538&��� -    ��Name$ nameTextBox��$
��Left=�$��22��$��329,197,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��200���� $��surname��$
��Left=�$��267,231,0,0q�$	��Top=��� -   $ surnameTextBox��$
��Left=�$��22��$��329,235,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��200���� $��
licence no��$
��Left=�$��261,267,0,0q�$	��Top=��� -   $ licNoTextBox��$
��Left=�$��22��$��329,271,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��200���� $	��age��$
��Left=�$��295,301,0,0q�$	��Top=��� -   $ 
ageTextBox��$
��Left=�$��22��$��329,305,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��200���� $
��Edit��$
��Left=�$��454,345,0,0q�$	��Top=�$��75������ *EditCommand+ �� Mode$ OneWay=���`�  `� 	Converter# [  .1���  �� ElementName$ nameTextBox�� �� Path$
 Text��� $ surnameTextBox��$
 Text��� $ licNoTextBox��$
 Text��� $ 
ageTextBox��$
 Text��� $��Edit user information��$
��Left=�$��329,114,0,0q�$	��Top=��� $��
identifier��$
��Left=�$��266,162,0,0q�$	��Top=��� $
��Left=�$��329,162,0,0q�$	��Top=����� $# (config:CurrentUserConfig.Id)��� $��Go back��$
��Left=�$��
10,520,0,0q�$	��Top=�$��75������ *GoToHomeCommand+$ OneWay=��� $
��Left=�$��329,372,0,0q�$	��Top=����� *Alert+