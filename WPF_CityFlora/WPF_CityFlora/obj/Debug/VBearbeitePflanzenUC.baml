   M S B A M L   `   `   `  ����H  DWPF_CityFlora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_CityFloraWPF_CityFlora  5      A%clr-namespace:WPF_CityFlora.ViewModelWPF_CityFlora.ViewModel  5      (    "WPF_CityFlora.VBearbeitePflanzenUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_CityFlora     5      8localv%clr-namespace:WPF_CityFlora.ViewModel     5        � 	Resources  5         vm S� 
ObjectType1  +WPF_CityFlora.ViewModel.VMBearbeitePflanzen��%"   &	        S� 5   
   "  6(   5      .��5      �  � DataContext 6   ��  �� Source# [   � ColumnDefinitions 5   
   �� 5      $	��22* �6   �� 5      $	��22* �6   �� 5      $	��22* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��Alle Pflanzen��61   $��Center=�6F   $
��Bold"�6c   �� 5   
   $��0��6   $��1��6!   $��Pflanzendaten��61   $��Center=�6F   $
��Bold"�6c   �� 5!   
   $��1��6   $��0��6   ��5"      ��  �� Path$ AllePflanzen� �� SelectedItem 5#      �� $ SelectedPflanze� �� Mode$ TwoWay=�	 �� BindsDirectlyToSource	 . ��5$      �� 5%      .R�5&      �� �� 5'      �6   �� $
 P_ID� �� 5(      $
��Bold"�6;   �6   �� $ P_Name�6;   5)      5*      5,      �� 5.   
   $��1��6   $��1��6"   $��10q�63   .+�50      ��  6   �� $ SelectedPflanze�.+�52      �� $��Pflanzen ID:��6   �� 53      ��6   �� *P_ID+�� 55      $��0 8 0 0q�6   $��Name der Pflanze:��6-   �� 56      ��6   �� *P_Name+�� 58      $��0 8 0 0q�6   $��Gepflanzt am:��6-   (  "System.Windows.Controls.DatePicker  59      
   SelectedDate
 6   �� *P_Gepflanzt+�� 5;      $��0 8 0 0q�6   $��Blumentopf:��6-   �� 5<       �� DisplayMemberPath$
 T_ID��5>       �� SelectedValuePath$
 T_ID��5?       �� SelectedValue 5<      �� *P_Topf+��5=      �� # [  $ AlleTopf�5?      �� 5A      $��0 8 0 0q�6   $��Blüht von:��6-     5B      
 6   �� *P_Bluet_Von+�� 5D      $��0 8 0 0q�6   $��Blüht bis:��6-     5E      
 6   �� *P_Bluet_Bis+�� 5G      $��0 8 0 0q�6   $��Notiz:��6-   �� 5H      $��40��63   ��6   �� *	P_Notiz+63   �� 5J      $��0 8 0 0q�6   $��Schädlinge:��6-   �� 5K      ��6   �� # [  $ 
HatSchaden�5L      5M      �� 5O   
   $��1��6   $��2��6"   $��10q�63   .+�5Q      ��  6   �� $ SelectedPflanze�.+�5R      �� $��0 8 0 0q�6   $��Schädlingsauswahl:��6/   �� 5S      $ S_Bez��5U   !   $
 S_ID��5V   !    5S      �� *P_Schaedling+��5T      �� # [  $ AlleSchadlingePf�5V   !   �� 5X      $��0 8 0 0q�6   $��	Standort:��6-   �� 5Y      $ SO_Bez��5[      $ SO_ID��5\       5Y      �� $ 
P_Standort���5Z      �� # [  $ AlleStandortP�5\      �� 5^      $��0 8 0 0q�6   $��Steckbrief:��6-   �� 5_      $ ST_Name��5a      $ ST_ID��5b       5_      �� $ P_Steckbrief���5`      �� # [  $ AlleSteckbrief�5b      �� 5d      $��0 8 0 0q�6   $��Rechnungs Nr:��6-   �� 5e      $
 K_ID��5g      $
 K_ID��5h       5e      �� $ P_Kauf���5f      �� # [  $ AlleKauf�5h      5j      �� 5l      $��Pflanze aktualisieren��6   $��
50 20 50 0q�6U   ��65   �� *SaveCommand+6U   �� 5m      $��Pflanze hinzufügen��6   $��
50 10 50 0q�6Q   ��62   �� *
NewCommand+6Q   �� 5n      $��Pflanze löschen��6   $��
50 10 50 0q�6Q   ��6/   �� *DeleteCommand+6Q   5o      5q      5s      