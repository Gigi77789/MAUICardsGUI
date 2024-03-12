using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MAUICardsGUI
{
    public class ImagesViewModel 
    {
        public ObservableCollection<ImageItem> Images { get; set; }

        public ImagesViewModel()
        {
            Images = new ObservableCollection<ImageItem> {
                new ImageItem ("card_clubs_02.png", "2C"),
               
                // etc.
            };
        }

     

    }

}
