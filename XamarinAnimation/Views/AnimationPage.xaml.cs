using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinAnimation.Models;

namespace XamarinAnimation.Views
{
    public partial class AnimationPage : ContentPage
    {
        private ObservableCollection<AnimationTypeModel> animationTypes;
        public AnimationPage()
        {
            InitializeComponent();
            animationTypes = new ObservableCollection<AnimationTypeModel>();
            animationTypesList.ItemsSource = animationTypes;
            animationTypesList.ItemTapped += (sender, e) => { Animate_Clicked(e.Item as AnimationTypeModel); };

            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Rotate", Index = 1, Details = "This code animates the Image instance by rotating up to 360 degrees over 2 seconds (2000 milliseconds). The RotateTo method obtains the current Rotation property value for the start of the animation, and then rotates from that value to its first argument (360). Once the animation is complete, the image's Rotation property is reset to 0. This ensures that the Rotation property doesn't remain at 360 after the animation concludes, which would prevent additional rotations." });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Relative", Index = 2, Details = "This code animates the Image instance by rotating 360 degrees from its starting position over 2 seconds (2000 milliseconds). The RelRotateTo method obtains the current Rotation property value for the start of the animation, and then rotates from that value to the value plus its first argument (360). This ensures that each animation will always be a 360 degrees rotation from the starting position. Therefore, if a new animation is invoked while an animation is already in progress, it will start from the current position and may end at a position that is not an increment of 360 degrees." });


			labelDetails.Text = "The animation extension methods in the ViewExtensions class are all asynchronous and return a Task<bool> object. The return value is false if the animation completes, and true if the animation is cancelled. Therefore, the animation methods should typically be used with the await operator, which makes it possible to easily determine when an animation has completed. In addition, it then becomes possible to create sequential animations with subsequent animation methods executing after the previous method has completed. For more information, see Compound Animations.\n\nIf there's a requirement to let an animation complete in the background, then the await operator can be omitted. In this scenario, the animation extension methods will quickly return after initiating the animation, with the animation occurring in the background. This operation can be taken advantage of when creating composite animations";
        }

        public async void Animate_Clicked(AnimationTypeModel model)
        {
            labelDetails.Text = model.Details;
            switch(model.Index)
            {
                case 1 :
                        await imageDisplay.RotateTo(360, 2000);
                        imageDisplay.Rotation = 0;
                    break;
				case 2 :
                        await imageDisplay.RelRotateTo(360, 2000);
					break;
            }
        }
    }
}
