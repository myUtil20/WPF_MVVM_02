   M S B A M L   `   `   `  ����H  DWPF_CityFlora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_CityFloraWPF_CityFlora  5      A%clr-namespace:WPF_CityFlora.ViewModelWPF_CityFlora.ViewModel  5      $    WPF_CityFlora.VBearbeiteTopfUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_CityFlora     5      8localv%clr-namespace:WPF_CityFlora.ViewModel     5        � 	Resources  5         vm S� 
ObjectType-  'WPF_CityFlora.ViewModel.VMBearbeiteTopf��%"   &	        S� 5   
   "  6(   5      .��5      �  � DataContext 6   ��  �� Source# [   � ColumnDefinitions 5   
   �� 5      $	��22* �6   �� 5      $	��22* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��Alle Blümentöpfe��61   $��Center=�6I   $
��Bold"�6f   �� 5   
   $��0��6   $��1��6!   $��Blumentopfdaten��61   $��Center=�6H   $
��Bold"�6e   �� 5   
   $��1��6   $��0��6    �� DisplayMemberPath$
 T_ID��5!      $��0 0 0 5q�5"   e   ��5       ��  �� Path$ 	AlleTopfe� �� SelectedValue 5"      �� $ SelectedTopf�	 �� Mode$	 TwoWay=�
 �� BindsDirectlyToSource
 . 6e   �� 5$   
   $��1��6   $��1��6"   $��10q�63   .+�5&      ��  6   �� $ SelectedTopf�.+�5(      �� $��0 8 0 0q�6   $��Blumentopf ID:��6-   $
��Bold"�6C   �� 5)      $��5q�6   ��6%   �� *T_ID+�� 5+      $��0 8 0 0q�6   $��Breite:��6-   $
��Bold"�6<   �� 5,      $��5q�6   ��6%   �� *
T_Breite+�� 5-      $��0 8 0 0q�6   $��Tiefe:��6-   $
��Bold"�6;   �� 5.      $��5q�6   ��6%   �� *	T_Tiefe+�� 5/      $��0 8 0 0q�6   $��Höhe:��6-   $
��Bold"�6:   �� 50      $��5q�6   ��6%   �� *	T_Hoehe+�� 52      $��0 8 0 0q�6   $��	Standort:��6-   $
��Bold"�6>   �� 53      $��	5 5 160 5q�6   $ SO_Bez��55       �� SelectedValuePath$ SO_ID��56       53   .   �� $ 
T_Standort���54      �� # [  $ AlleStandortT�56      58      �� 5;      $��Blumentopf aktualisieren��6   $��
50 20 50 0q�6X   ��68   �� *SaveCommand+6X   �� 5<      $��Blumentopf hinzufügen��6   $��
50 10 50 0q�6T   ��65   �� *
NewCommand+6T   �� 5=      $��Blumentopf löschen��6   $��
50 10 50 0q�6T   ��62   �� *DeleteCommand+6T   5>      5@      5B      