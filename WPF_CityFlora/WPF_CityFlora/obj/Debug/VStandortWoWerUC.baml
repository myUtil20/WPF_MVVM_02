   M S B A M L   `   `   `  ����H  DWPF_CityFlora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_CityFloraWPF_CityFlora  5      A%clr-namespace:WPF_CityFlora.ViewModelWPF_CityFlora.ViewModel  5      $    WPF_CityFlora.VStandortWoWerUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WPF_CityFlora     5      8localv%clr-namespace:WPF_CityFlora.ViewModel     5        � 	Resources  5         vm S� 
ObjectType-  'WPF_CityFlora.ViewModel.VMStandortWoWer��%"   &	        S� 5   
   "  6(   5      .��5      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��131* �6   �� 5      $
��297* �6   .+�5   
   �� $��Standort auswählen:��6   $
��10 5q�6/   �� 5   
   $	��300��6   $
��Left=�6   $��130 5q�6:    �� DisplayMemberPath$ SO_Bez��5       �� SelectedValuePath$ SO_ID��5!      ��5      �� *
AlleOrte+ �� SelectedItem 5       ��  �� Path$ GewaehlterOrt�	 �� Mode$	 TwoWay=�
 �� BindsDirectlyToSource
 . 5!      &   System.Windows.Controls.DataGrid  5$   
   $��1��6      AutoGenerateColumns .     
IsReadOnly .  $��2��5%   G   $��-1,0,1,0q�6X   ��6   �� *AllePflanzenDesStandortes+   Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$
 P_ID��6%      
FontWeight$
 Bold"�6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *P_ID+6L     5(      $
 Name��6%    63   �� *P_Name+  5)      $ Gepflanzt am��6%    6;   �� *P_Gepflanzt+  5*      $ SOrt-ID��6%      	FontStyle$ Oblique$�6U    66   �� *
P_Standort+6U     5+      $ Topf-ID��6@   $ Oblique$�6Q    6%   �� *P_Topf+6Q     5,      $ 	Blüt von��6E    6%   �� *P_Bluet_Von+6E     5-      $ 	Blüt bis��6E    6%   �� *P_Bluet_Bis+6E     5.      $ Schädlings-ID��6F   $ Oblique$�6]    6%   �� *P_Schaedling+6]     5/      $ Notizen��6A    6%   �� *	P_Notiz+6A   51      53      54      