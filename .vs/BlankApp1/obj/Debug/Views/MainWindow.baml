   M S B A M L   `   `   `  ����  	BlankApp1     BlankApp1.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59[ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5   	   $	��700��5   !   $
��1200��6.    � Title 6	   �� *Title+.��5      �  � ColumnDefinitions 5   
   �� 5	      $��1* �6   �� 5
      $��3* �6   .+�5   
   �� $��0��6   
����+��.+�5      �  � RowDefinitions 5      �� 5      $	��100 �6$   �� 5      $	��100 �6$   �� 5      $	��100 �6$   �� 5      $	��100 �6$   .+�5      �� $��0��6   $��Add Customer��6&   $��AddUser��6\   $��12(�6w   $��70��6�   $��10q�6�   ��6=   �� *
AddCommand+6�   �� 5      $��1��6   $��Update Data��6'   $��
UpdateUser��6_   $��12(�6}   $��70��6�   $��10q�6�   ��6=   �� *UpdateCommand+6�   �� 5      $��2��6   $��Delete Customer��6'   $��
DeleteUser��6c   $��12(�6�   $��70��6�   $��10q�6�   ��6A   �� *DeleteCommand+6�   �� 5      $��3��6   $��Retrive Customers��6'   $��RetrieveCustomers��6m   $��12(�6�   $��70��6�   $��10q�6�   ��6C   �� *GetAllCustomerCommand+6�   5      5      �� 5   
   $��1��6>   $��Center=�6N   $��Center=�6k   $��30(�6�   $
��Bold"�6�   ��6   �� *CompanyName+ �� Mode$ TwoWay=�6�   �� 5   
   !  Prism.Regions.RegionManager   
RegionName$ ContentRegion��6   $��1��6H   5      5      