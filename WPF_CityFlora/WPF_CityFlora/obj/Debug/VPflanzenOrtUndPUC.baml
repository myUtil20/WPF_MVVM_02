   M S B A M L   `   `   `  ����H  DWPF_CityFlora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_CityFloraWPF_CityFlora  5      A%clr-namespace:WPF_CityFlora.ViewModelWPF_CityFlora.ViewModel  5      &     WPF_CityFlora.VPflanzenOrtUndPUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_CityFlora     5      8localv%clr-namespace:WPF_CityFlora.ViewModel     5        � 	Resources  5         vm S� 
ObjectType/  )WPF_CityFlora.ViewModel.VMPflanzenOrtUndP��%"   &	        S� 5   
   "  6(   5      .��5      �  � DataContext 6   ��  �� Source# [   � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��	Standorte��61   $
��Bold"�5      $��Center=�6&    �� Padding$ 5q�6C   �� 5   
   $��0��6   $��1��6!   $��Pflanzen��61   $
��Bold"�5       $��Center=�6&   $ 5q�6C   �� 5!   
   $��0��6   $��2��6!   $��Pflanzendaten��61   $
��Bold"�5"      $��Center=�6&   $ 5q�6C   �� 5%   
   $��1��6   $��0��6    �� DisplayMemberPath$ SO_Bez��6Z   ��6/   ��  �� Path$ AlleStandorte�	 �� SelectedValue	 5&      �� $ GewaehlteStandortGui�
 �� Mode$
 OneWayToSource=� �� BindsDirectlyToSource . �� 5(   
   $��1��6   $��1��6   ��5)      �� $ PflanzeStandort� �� SelectedItem 5*      �� $ GewaehltePflanze�$
 TwoWay=� . ��5+      �� 5,      .R�5-      �� �� 5.      �6   �� $
 P_ID� �� 5/      $
��Bold"�6;   �6   �� $ P_Name�6;   50      51      53      �� 55   
   $��1��6   $��2��6"   $��5 5 5 0q�62   .+�56      ��  6   �� $ GewaehltePflanze�.+�58      �� $	��ID:��6   $
��Bold"�6'   �� 59      ��6   �� *P_ID+�� 5;      $��Name der neuen Pflanze:��6   $
��Bold"�6;   $��0 8 0 0q�6N   �� 5<      ��6   �� *P_Name+�� 5>      $��Gepflanzt am:��6   $
��Bold"�61   $��0 8 0 0q�6C   �� 5?      ��6   �� *P_Gepflanzt+ �� StringFormat$ 
dd.MM.yyyy���� 5A      $��Blumentopf:��6   $
��Bold"�6/   $��0 8 0 0q�6A   �� 5B      ��6   �� *P_Topf+�� 5D      $��Blüht von:��6   $
��Bold"�6.   $��0 8 0 0q�6@   �� 5E      ��6   �� *P_Bluet_Von+$ 
dd.MM.yyyy���� 5G      $��Blüht bis:��6   $
��Bold"�6.   $��0 8 0 0q�6@   �� 5H      ��6   �� *P_Bluet_Bis+$ 
dd.MM.yyyy���� 5J      $��Notiz:��6   $
��Bold"�6*   $��0 8 0 0q�6<   �� 5K      ��6   �� *	P_Notiz+5L      �� 5N      $��Pflanze bearbeiten��6   $��	15 5 15 5q�6R   ��62   �� *SaveCommand+6R   �� 5O      $��Pflanze neu��6   $��	15 5 15 5q�6J   ��6+   �� *
NewCommand+6J   �� 5P      $��Pflanze löschen��6   $��	15 5 15 5q�6Q   ��6/   �� *DeleteCommand+6Q   5Q      5S      5U      