   M S B A M L   `   `   `  ����   AFileOrganizer&     AFileOrganizer.AssociationWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Icon$  Imgs/Icono.ico�� � Title$ New Association��$��333.835��$��453.383�� � WindowStartupLocation$ CenterScreen=�.��� $��10q� � RowDefinitions �� $��20 ��� $��45 ��� $��20 ��� $��45 ��� $��20 ��� $��45 ��� $��* � � ColumnDefinitions �� $	��241 ��� $
��auto �$	��319��.+��� $��0��$��2�� �� TextAlignment$
 Left=�$��Times New Roman)�$��17(�$��SemiBold"�
��� � �$
��Name���� -    ��Name$ txtName��$��1��$��2��$	��415��$��Times New Roman)�$��15(�$��0,4,0,0q�$
��Left=�$��0,8,0,7q� �� 	MaxLength$	 100���� $��2��$��0��$
 Left=�$��Times New Roman)�$��17(�$��SemiBold"�
��� � �$��File extension���� -   $ txtExtension��$��3��$��0��$	��170��$��Times New Roman)�$��15(�$��0,4,0,0q�$
��Left=�$��0,7,0,8q�$ 10���� $��2��$��1��$
 Left=�$��Times New Roman)�$��17(�$��SemiBold"�
��� � �$��Action��$
��Left=�$��48���� -    ��Name$ 
cmbActions��$��3��$��1��$��Times New Roman)�$��17(�$��Normal"�$	��174��$
��Left=�$��0,7,0,8q�.@��� $
��Move��	 �� 
IsSelected	 . �� $��Delete��	 . �� $��4��$��0��$
 Left=�$��Times New Roman)�$��17(�$��SemiBold"�
��� � �$��Destination folder���� -   $ txtDestination��$��5��$��0��$	��356��$��Times New Roman)�$��15(�$��0,4,0,0q�$
��Left=�
 �� 
IsReadOnly
 . $��2��$��0,8,0,7q��� -    ��Name$ btnChooseFolder��$��5��$��1��
�������
��� � �$	��0.8q�$��50��$��	120,5,0,5q�$
��Left=�.���� $��Imgs/folder.png���� -   $ btnSave��$��6��$��0��
�������$��Times New Roman)�$��22(�$��SemiBold"�
��� � �$��60��$	��100��.���� $��Imgs/save.png���� -   $ 	btnCancel��$��6��$��1��
�������$��Times New Roman)�$��22(�$��SemiBold"�
��� � �$��60��$	��100��$
��Left=�.���� $��Imgs/cancel.png��