   M S B A M L   `   `   `  ����  AFileOrganizer(    "AFileOrganizer.AssociationsManager   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Icon$  Imgs/Icono.ico��5   	    � Title$ Manage Associations��5   	   $	��321��6%   $	��334��62    � WindowStartupLocation$ CenterScreen=�6>   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��30 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgAssociations��5      $��0��5         CanUserAddRows .  5   *   �� 5   
   -   5         ��Name$ btnNew��5      $��1��5      
��� � �
�������$
��Left=�5      $	��100��5       � ToolTip$ New Association��5       .��5#      �� $��Imgs/add.png��6   5$      �� 5&   
   -   5        $ 	btnDelete��5&      $��1��5'      
��� � �
�������$��Center=�5*      $	��100��5+      $ Delete association��5,      .��5/      �� $��Imgs/delete.png��6   50      �� 52   
   -   5        $ 	btnCancel��52      $��1��53      
��� � �
�������$��Right=�56      $	��100��57      $ Cancel and close��58      .��5;      �� $��Imgs/cancel.png��6   5=      �� 5?   
   -   5        $ 	btnUpdate��5?      $��2��5@      
��� � �
�������$ Edit information��5C      .��5F      �� $��Imgs/edit.png��6   5H      5J      5K      