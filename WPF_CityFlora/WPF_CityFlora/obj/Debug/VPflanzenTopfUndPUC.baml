   M S B A M L   `   `   `  ����H  DWPF_CityFlora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_CityFloraWPF_CityFlora  5      A%clr-namespace:WPF_CityFlora.ViewModelWPF_CityFlora.ViewModel  5      '    !WPF_CityFlora.VPflanzenTopfUndPUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_CityFlora     5      8localv%clr-namespace:WPF_CityFlora.ViewModel     5        � 	Resources  5         vm S� 
ObjectType0  *WPF_CityFlora.ViewModel.VMPflanzenTopfUndP��%"   &	        S� 5   
   "  6(   5      .��5      �  � DataContext 6   ��  �� Source# [   � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��	Standorte��61   $
��Bold"�5       $��Center=�6&    �� Padding$ 5q�6C   �� 5!   
   $��0��6   $��1��6!   $��Blumentöpfe��61   $
��Bold"�5"      $��Center=�6&   $ 5q�6C   �� 5#   
   $��0��6   $��2��6!   $��Blumentopfdaten��61   $
��Bold"�5$      $��Center=�6&   $ 5q�6C   �� 5%   
   $��0��6   $��3��6!   $��Pflanzen im Blumentopf��61   $
��Bold"�5&      $��Center=�6&   $ 5q�6C   �� 5'   
   $��0��6   $��4��6!   $��Pflanzendaten��61   $
��Bold"�5(      $��Center=�6&   $ 5q�6C   �� 5*   
   $��1��6   $��0��6    �� DisplayMemberPath$ SO_Bez��6Z   ��6/   ��  �� Path$ AlleStandorte�	 �� SelectedValue	 5+      �� $ GewaehlteStandortGui�
 �� Mode$
 OneWayToSource=� �� BindsDirectlyToSource . �� 5.   
   $��1��6   $��1��6   ��6/   �� $ TopfStandort� �� SelectedItem 6Y   �� $ GewaehlterTopf�$
 TwoWay=� . ��5/      �� 50      .R�51      �� �� 52      $
��Bold"�69   �6   �� $
 T_ID�69   53      54      56      �� 59   
   $��1��6   $��2��6"   $��5 5 5 0q�62   .+�5:      ��  6   �� $ GewaehlterTopf�.+�5<      �� $��Topf ID:��6   $
��Bold"�6,   �� 5=      ��6   �� *T_ID+�� 5?      $��Tiefe:��6   $
��Bold"�6*   $��0 8 0 0q�6=   �� 5@      ��6   �� *	T_Tiefe+�� 5B      $��Breite:��6   $
��Bold"�6+   $��0 8 0 0q�6>   �� 5C      ��6   �� *
T_Breite+�� 5E      $��Höhe:��6   $
��Bold"�6)   $��0 8 0 0q�6<   �� 5F      ��6   �� *	T_Hoehe+5H      �� 5J      $��Blumentopf bearbeiten��6   $��	15 5 15 5q�6V   ��65   �� *SaveCommandT+6V   �� 5K      $��Blumentopf hinzufügen��6   $��	15 5 15 5q�6U   ��65   �� *NewCommandT+6U   �� 5L      $��Blumentopf löschen��6   $��	15 5 15 5q�6U   ��62   �� *DeleteCommandT+6U   5M      �� 5Q   
   $��1��6   $��3��6   ��6/   �� $ PlanzeImTopf� 6Y   �� $ GewaehltePflanze�$
 TwoWay=� . ��5R      �� 5S      .R�5T      �� �� 5U      �6"   �� *P_Name+5V      5W      5Y      �� 5\   
   $��1��6   $��4��6"   $��5 5 5 0q�62   .+�5]      ��  6   �� $ GewaehltePflanze�.+�5_      �� $��Pflanzen ID:��6   �� 5`      ��6   �� *P_ID+�� 5b      $��Name der neuen Pflanze:��6   $
��Bold"�6<   �� 5c      ��6   �� *P_Name+�� 5e      $��Gepflanzt am:��6   $��0 8 0 0q�62   $
��Bold"�6C   �� 5f      ��6   �� *P_Gepflanzt+ �� StringFormat$ 
dd.MM.yyyy���� 5h      $��Blumentopf:��6   $��0 8 0 0q�60   $
��Bold"�6A   �� 5i      ��6   �� *P_Topf+�� 5k      $��	Standort:��6   $��0 8 0 0q�6.   $
��Bold"�6?   �� 5l      ��6   �� *
P_Standort+�� 5n      $��Blüht von:��6   $��0 8 0 0q�6/   $
��Bold"�6@   �� 5o      ��6   �� *P_Bluet_Von+$ 
dd.MM.yyyy���� 5q      $��Blüht bis:��6   $��0 8 0 0q�6/   $
��Bold"�6@   �� 5r      ��6   �� *P_Bluet_Bis+$ 
dd.MM.yyyy���� 5t      $��Notiz:��6   $��0 8 0 0q�6+   $
��Bold"�6<   �� 5u      ��6   �� *	P_Notiz+5x      �� 5z      $��Pflanze bearbeiten��6   $��	15 5 15 5q�6R   ��62   �� *SaveCommand+6R   �� 5{      $��Pflanze hinzufügen��6   $��	15 5 15 5q�6Q   ��62   �� *
NewCommand+6Q   �� 5|      $��Pflanze löschen��6   $��	15 5 15 5q�6Q   ��6/   �� *DeleteCommand+6Q   5}      5      5�      