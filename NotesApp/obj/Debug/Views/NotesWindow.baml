   M S B A M L   `   `   `  ����C  ?NotesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NotesApp.ViewsNotesApp.Views  5   	   9!clr-namespace:NotesApp.ViewModelsNotesApp.ViewModels  5   	   A%clr-namespace:NotesApp.Views.ControlsNotesApp.Views.Controls  5   	   O,clr-namespace:NotesApp.ViewModels.ConvertersNotesApp.ViewModels.Converters  5	   	        NotesApp.Views.NotesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NotesApp.Views     5   	   0vm!clr-namespace:NotesApp.ViewModels     5   	   4uc%clr-namespace:NotesApp.Views.Controls     5   	   ;vc,clr-namespace:NotesApp.ViewModels.Converters     5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	     � Title$  NotesWindow��5   	   $	��450��6   $	��800��6*    � 	Resources 5      !   NotesApp.ViewModels.NotesVM   VM7   1NotesApp.ViewModels.Converters.BoolToVisConverter  	BoolToVis��%:   &	        &	        5   
   6     5   
   6    5      .��5      ]� -   5         ]�Name$ ContainerDockPanel��5      .+�5   
   o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $��New Notebook��6    m� Command 5      �� *NewNotebookCommand+m� 5      $��New Note��6    5      �� *NewNoteCommand+ m� CommandParameter 5      �� *SelectedNotebook+�� 5      m� 5      -   5        $
��Exit��5      5      5      5      �� 5   
   $��Bottom=�6   .@�5      �� -   5         ��Name$ statusTextBlock��5      5       �� 5!   
   $
��Left=�6   $	��140��5"      
���p���5$      �� *	Notebooks+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5%      �� *SelectedNotebook+$ TwoWay=�$ PropertyChanged=���5(      �� 5)      .R�5*      � .+�5+      1   +NotesApp.Views.Controls.NotebookUserControl  	   DisplayNotebook	 61   �� �� 5,      ��6"   �� *Name+$ TwoWay=�$ PropertyChanged=�y�5/   #   �� 
 �� Source#
 [   �� Path$ 	IsEditing� �� 	Converter# [ .��6�   .  (System.Windows.Interactivity.Interaction   Triggers 50      /  )System.Windows.Interactivity.EventTrigger  51   "      	EventName$ 	LostFocus��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 52   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� #
 [  $ HasNotebookRenamedCommand�   CommandParameter 53   <   �� 54   #   .��55   6   56       � ContextMenu 57      �� 58      .@�59   "   m� $��Rename��6+    5:   +   �� #
 [  $ RenameNoteBookCommand�m� 5;   "   $��Delete��6+    5<   +   �� #
 [  $ DeleteNotebookCommand� 5=   +   �� 5>      5@      5A      5C      �� 5D   
   $
��Left=�6   $	��140��5E       5F      �� *SelectedNote+��5G      �� *Notes+��5H      �� 5I      .R�5J      � .+�5K      -   'NotesApp.Views.Controls.NoteUserControl     DispalyNote 6-   �� �� 5L      ��6"   �� *Title+$ TwoWay=�$ PropertyChanged=�y�5O   "   �� #
 [  $ IsNoteEditing�# [ .��6�    5P        5Q   "   $ 	LostFocus��61   . 5R   &      6<   �� #
 [  $ HasNoteRenamedCommand� 5S   <   �� 5T   #   .��5U   6   5V       5W      �� 5X      .@�5Y   "   m� $��Rename��6+    5Z   +   �� #
 [  $ RenameNoteCommand�m� 5[   "   $��Delete��6+    5\   +   �� #
 [  $ DeleteNoteCommand� 5]   +   �� 5^      5`      5b      5d      `� 5e   
   $	��Top=�6   .�5f      c� .@�5g      d� -   5         d�Name$ speechButton��5g      $��Speech��5h      5i      d� 5j      -   5        $ 
boldButton��5j      .��5l      �� $��B��6    $
��Bold"�5m       5n      d� 5o      -   5        $ italicButton��5o      .��5q      �� $��I��6    $��Italic$�5r       5s      d� 5t      -   5        $ underlineButton��5t      .��5v      �� $��U��6    $��	Underline{�5w       5x      �� 5y      -   5         ��Name$ fontFamilyComboBox��5y      $	��100��5z      5{      �� 5|      -	   5        $ fontSizeComboBox��5|      $��50��5}       �� 
IsEditable . 5      �� 5�      -
   5         ��Name$ SaveFileButton��5�      $
��Save��5�      5�      5�      5�      � 5�   
   .+�5�      �� -   5         ��Name$ contentReachTextBox��5�      5�      5�      5�      5�      