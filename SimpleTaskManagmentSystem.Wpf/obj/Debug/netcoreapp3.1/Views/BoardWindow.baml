   M S B A M L   `   `   `  ����X  TSimpleTaskManagmentSystem.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SimpleTaskManagmentSystem.Wpf.Views#SimpleTaskManagmentSystem.Wpf.Views  5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   c _Syncfusion.SfKanban.WPF, Version=18.2310.0.44, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89fHclr-namespace:Syncfusion.UI.Xaml.Kanban;assembly=Syncfusion.SfKanban.WPFSyncfusion.UI.Xaml.Kanban 5   	   c6clr-namespace:SimpleTaskManagmentSystem.Wpf.ViewModels(SimpleTaskManagmentSystem.Wpf.ViewModels  5	   	   5    /SimpleTaskManagmentSystem.Wpf.Views.BoardWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:SimpleTaskManagmentSystem.Wpf.Views     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   _
syncfusionHclr-namespace:Syncfusion.UI.Xaml.Kanban;assembly=Syncfusion.SfKanban.WPF     5   	   M
viewModels6clr-namespace:SimpleTaskManagmentSystem.Wpf.ViewModels     5	   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak	 gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks  	 5
   	     � Title$  BoardWindow��5   	   $	��450��6   $
��2400��6*    � WindowState$ 	Maximized=�67    � 
ResizeMode$ CanMinimize=�6O   .��5      ]� .+�5   
   �� $
��Left=�6   $��0 1 1 0q�5      
���������5      �� *TaskViewWidth+._�5      ]� .+�5      �� $��Bottom=�6   $��1q�5      
�������$��50��5      ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6/   �� 5      $��* �6/   .+�5      �� $��0��6!   ��5   !   �� *CloseTaskViewCommand+��5       �� 5!   "   .R�5"   &   �� .+�5#   *   3 	 -MahApps.Metro.IconPacks.FeatherIconsExtension     Kind$
 Plus=�6<   5$   '   5%   #   5'      �� 5(      $��1��5)      $��Center=�5*      $��Center=�5+      .+�5,      �� $��11(�5/   !   $
��Wrap=�50   !    �� TextAlignment$ Center=�51   !   ��5-   !   �� *SelectedTask.CreatedDate+ �� StringFormat$ Created at {0:t}��51   !   �� 52      $��11(�55   !   $
��Wrap=�56   !   $ Center=�57   !   ��53   !   �� *SelectedTask.CreatedDate+$ {0:D}��57   !   58      5C      5D      �� 5E      $
��Auto=�6   .��5F      ��  �� Orientation$ Vertical=�6!   .+�5G      �� $��10q�6%   .+�5N      ��  �� DisplayMemberPath$
 Name��5P   '   $��0 0 0 10q�5Q   '   *  $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$
	 Type��5R   '   
   UseFloatingWatermark$

 True��5S   '   ��5N   '   �� *	TaskTypes+ �� SelectedValue 5O   '   �� *SelectedTask.Type+5S   '   �� 5T      $��0 0 0 10q�5U   &   $��14(�5V   &   $	 Description��5W   &   $

 True��5X   &    �� TextWrapping$
 Wrap=�5Y   &    �� 
AcceptsTab$
 True��5Z   &    �� AcceptsReturn$
 True��5[   &    �� MinLines$ 3��5\   &   ��5T   &   �� *SelectedTask.Description+ �� UpdateSourceTrigger$ PropertyChanged=�5\   &   (  "System.Windows.Controls.DatePicker  5]         SelectedDateFormat$
 Long=�6)      DisplayDateStart 1/01/095^   #      DisplayDateEnd 12/31/306>      FirstDayOfWeek$ Monday=�5_   #   $	 Required By Date��6;   $

 True��5`   &      SelectedDate 5]   C   �� *SelectedTask.RequiredByDate+5`   &   ]� 5a      $��Center=�6(   $��0 0 0 10q�5b   (   .+�5c   "   �� $
 Wrap=�5d   *   $	 Assignment To��5e   *   ��5c   *   �� *%#Model.SelectedTask.User.DisplayName+$ PropertyChanged=�.��5e   V    J� InputBindings 5f   &   �� 5g   *   
 �� Key$ Enter��5i   -    �� Command 5h   -   �� *AssignmentToCommand+5i   -   .��5j   =   5k   #   5l      �� 5n      $��	Comments:��6(   $��16(�69   $��0 0 0 10q�6G     5o      $
 Long=�6)    1/01/095p   #    12/31/306>   $ Monday=�5q   #   $	 Action Date��6;   $

 True��5r   &   $��0 0 0 10q�6T    5o   C   �� *SelectedTask.RequiredByDate+5r   T   �� 5s      $
 Name��5u   '   $��0 0 0 10q�5v   '   $	 Comments Type��5w   '   $

 True��5x   '   ��5s   '   ��  �� Path$ CommentTypes� 5t   '   �� $ SelectedTask.Comment.Type�5x   '   �� 5y      $��0 0 0 10q�5z   &   $��14(�5{   &   $

 True��5|   &   $
 Wrap=�5}   &   $
 True��5~   &   $
 True��5   &   $	 Add Comment��5�   &   $ 3��5�   &   ��5y   &   �� *SelectedTask.Comment.Content+$ PropertyChanged=�5�   &   �� 5�      $��10q�6'   ��63   �� *SelectedTask.Comments+��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� ��68   �� *
Owner.Name+�� 5�   .   ��68   �� *	Content+�� 5�   .   ��68   �� *CreatedDate+5�   +   5�   '   5�      �� 5�      $��Disabled=�6&   $��Disabled=�5�   &   5�      5�      5�      5�      5�      �� 5�   
   $
��Left=�6   
�������$��0 1 0 0q�6>   ._�5�      (  "Syncfusion.UI.Xaml.Kanban.SfKanban  -   5           MinColumnWidth$	 200Q�5�   "      MaxColumnWidth$	 400Q�5�   "   $��0q�5�   "      AutoGenerateColumns$ False��5�   "      ColumnMappingPath$ Category��5�   "      ItemsSource 5�   "   �� *Tasks+$ PropertyChanged=� �� Mode$ TwoWay=�    ColumnHeaderTemplate  5�      �� 5�      ! �� DataType$! syncfusion:ColumnTag��6#   .R�5�      �� ._�5�      �� $ Vertical=�6)   $��0 10 0 0q�5�   )   .+�5�   "   ]� .+�5�   &   �� $��Right=�6-   ��5�   -   �� " �� RelativeSource" �� # �� AncestorType"#  $  DataContext.AddTaskCommand���5�   -   �� *Header+��5�   *   �� 5�   .   .R�5�   2   �� .+�5�   6     $
 Plus=�6H   5�   3   5�   /   5�   '   �� 5�   &   $��20(�5�   0   ��5�   0   �� *Header+5�   0   5�   #   �� 5�   "   $��16(�5�   ,   $��0 10 0 0q�5�   ,   $
��Thin"�5�   ,   ��5�   ,   �� *	CardCount+$ 
Tasks: {0}��5�   ,   5�      5�      5�      $   CardTemplate$ 5�      �� 5�      .R�5�      �� $��1q�6!   % �� CornerRadius$% 4��5�   !   
�������$��0,5,0,5q�5�   !   ._�5�      �� $��	10,5,5,10q�6)   .+�5�   "   �� $
 Wrap=�5�   *   & �� MaxLines$& 2��5�   *   $��0q�5�   *   ${�False��5�   *   $
��Bold"�5�   *   $��16(�5�   *   ��5�   *   �� *Type+5�   *   �� 5�   "   $��14(�6*   $��0q�5�   *   ${�False��5�   *   $
��Left=�5�   *   $& 3��5�   *   $
 Wrap=�5�   *   ��5�   *   �� *Description+5�   *   5�      5�      5�      '   Columns.' 5�      ,  &Syncfusion.UI.Xaml.Kanban.KanbanColumn  (   
Categories$
( Open��6*   )   Title$) Backlog��6<     5�      $( 
InProgress��6*   $) In Progress��6B     5�      $( Closed��6*   $) 	Completed��6>   5�      5�      �� 5�   
   $
��Left=�6   $��1 0 1 0q�5�      
�������._�5�      ]� .+�5�      � * � RowDefinitions* 5�      �� 5�      $
��Auto �6(   68   �� 5�      $
��Auto �6(   68   �� 5�      $��* �6(   65   .+�5�      �� $��Search for Comments:��6    $��16(�6<   $ Center=�6J   6d   �� 5�      $��1��6   $
 Wrap=�5�      $'	 !Enter search text and press Enter��5�      $

 True��5�      ��5�      �� *SearchComment+$ PropertyChanged=�$ TwoWay=�.��5�   G    5�      �� 5�      $ Enter��5�   !    5�   !   �� *SearchCommentCommand+5�   !   .��5�   1   5�      �� 5�      $��2��6   ��6,   �� *FilteredItems+��5�      �� 5�      .R�5�   "   �� ��6,   �� *	Content+6G   5�      5�      5�      5�      5�      5�      5�      