   M S B A M L   `   `   `  ����A  =XUMHUB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:XUMHUB.ViewXUMHUB.View  5          XUMHUB.View.CSVUploadView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:XUMHUB.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��15 0 0 0q�62   .+�5      �� $��PO Number: ��6    	  Label#��[  6/   $��Center=�6N   �� 5      $��Center=�6   $��150px��66   ��6D   �� *
PoNumber+ �� UpdateSourceTrigger$ PropertyChanged=�5      5      � 5   
   $��1��6   .+�5      �� $ 
Horizontal=�6   $��15 0 0 0q�62   .+�5      �� $��
PO Title: ��6   #��[  6.   $��Center=�6M   �� 5      $��Center=�6   $��150px��66   ��6D   �� *	POTitle+$ PropertyChanged=�5      5      � 5   
   $��2��6   .+�5      �� $ 
Horizontal=�6   $��15 0 0 0q�62   .+�5       �� $��
CSV Path: ��6   #��[  6.   $��Center=�6M   �� 5!      $��Open CSV��6   ��6,   �� *OpenFileCommand+5"      5#      � 5$   
   $��3��6   .+�5%      �� $
��Save��6   ��6$   �� *Save+5'      5(      5)      