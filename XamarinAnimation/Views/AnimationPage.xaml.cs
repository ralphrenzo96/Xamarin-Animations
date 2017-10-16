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
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Relative Rotation", Index = 2, Details = "This code animates the Image instance by rotating 360 degrees from its starting position over 2 seconds (2000 milliseconds). The RelRotateTo method obtains the current Rotation property value for the start of the animation, and then rotates from that value to the value plus its first argument (360). This ensures that each animation will always be a 360 degrees rotation from the starting position. Therefore, if a new animation is invoked while an animation is already in progress, it will start from the current position and may end at a position that is not an increment of 360 degrees." });

            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Scaling", Index = 3, Details = "This code animates the Image instance by scaling up to twice its size over 2 seconds (2000 milliseconds). The ScaleTo method obtains the current Scale property value (default value of 1) for the start of the animation, and then scales from that value to its first argument (2). This has the effect of expanding the size of the image to twice its size." });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Relative Scaling", Index = 4, Details = "This code animates the Image instance by scaling up to twice its size over 2 seconds (2000 milliseconds). The RelScaleTo method obtains the current Scale property value for the start of the animation, and then scales from that value to the value plus its first argument (2). This ensures that each animation will always be a scaling of 2 from the starting position." });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Scaling and Rotation with Anchors", Index = 5, Details = "The AnchorX and AnchorY properties set the center of scaling or rotation for the Rotation and Scale properties. Therefore, their values also affect the RotateTo and ScaleTo methods." });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Translation", Index = 6, Details = "This code animates the Image instance by translating it horizontally and vertically over 1 second (1000 milliseconds). The TranslateTo method simultaneously translates the image 100 pixels to the left, and 100 pixels upwards. This is because the first and second arguments are both negative numbers. Providing positive numbers would translate the image to the right, and down." });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Fading", Index = 7, Details = "This code animates the Image instance by fading it in over 4 seconds (4000 milliseconds). The FadeTo method obtains the current Opacity property value for the start of the animation, and then fades in from that value to its first argument (1)." });


            //animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "", Index = 3, Details = ""});

			labelDetails.Text = "The animation extension methods in the ViewExtensions class are all asynchronous and return a Task<bool> object. The return value is false if the animation completes, and true if the animation is cancelled. Therefore, the animation methods should typically be used with the await operator, which makes it possible to easily determine when an animation has completed. In addition, it then becomes possible to create sequential animations with subsequent animation methods executing after the previous method has completed. For more information, see Compound Animations.\n\nIf there's a requirement to let an animation complete in the background, then the await operator can be omitted. In this scenario, the animation extension methods will quickly return after initiating the animation, with the animation occurring in the background. This operation can be taken advantage of when creating composite animations";
        }

        public async void Animate_Clicked(AnimationTypeModel model)
        {
            labelName.Text = model.Name;
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
				case 3:
					await imageDisplay.ScaleTo(0.5, 2000);
					break;
				case 4:
					await imageDisplay.RelScaleTo(0.5, 2000);
					break;
				case 5:
					imageDisplay.AnchorY = (Math.Min(stackParent.Width, stackParent.Height) / 2) / imageDisplay.Height;
					await imageDisplay.RotateTo(360, 2000);
					break;
				case 6:
					await imageDisplay.TranslateTo(-50, -50, 1000);
					break;
				case 7:
					imageDisplay.Opacity = 0;
					await imageDisplay.FadeTo(1, 4000);
					break;
            }
        }
    }
}
