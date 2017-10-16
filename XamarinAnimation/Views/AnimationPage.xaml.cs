using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Compound Animations", Index = 8, Details = "In this example, the Image is translated over 6 seconds (6000 milliseconds). The translation of the Image uses five animations, with the await operator indicating that each animation executes sequentially. Therefore, subsequent animation methods execute after the previous method has completed." });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Composite Animations", Index = 9, Details = "In this example, the Image is scaled and simultaneously rotated over 4 seconds (4000 milliseconds). The scaling of the Image uses two sequential animations that occur at the same time as the rotation. The RotateTo method executes without an await operator and returns immediately, with the first ScaleTo animation then beginning. The await operator on the first ScaleTo method call delays the second ScaleTo method call until the first ScaleTo method call has completed. At this point the RotateTo animation is half way completed and the Image will be rotated 180 degrees. During the final 2 seconds (2000 milliseconds), the second ScaleTo animation and the RotateTo animation both complete." });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Running Multiple Asynchronous Methods Concurrently", Index = 10, Details = "The static Task.WhenAny and Task.WhenAll methods are used to run multiple asynchronous methods concurrently, and therefore can be used to create composite animations. Both methods return a Task object and accept a collection of methods that each return a Task object. The Task.WhenAny method completes when any method in its collection completes execution" });
            animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "Running Multiple Asynchronous Methods Concurrently", Index = 11, Details = "In this example, the Task.WhenAny method call contains two tasks. The first task rotates the image over 4 seconds (4000 milliseconds), and the second task scales the image over 2 seconds (2000 milliseconds). When the second task completes, the Task.WhenAny method call completes. However, even though the RotateTo method is still running, the second ScaleTo method can begin." });
            //animationTypes.Add(new AnimationTypeModel { Image = "anim_01", Name = "", Index = 3, Details = ""});

			labelDetails.Text = "The animation extension methods in the ViewExtensions class are all asynchronous and return a Task<bool> object. The return value is false if the animation completes, and true if the animation is cancelled. Therefore, the animation methods should typically be used with the await operator, which makes it possible to easily determine when an animation has completed. In addition, it then becomes possible to create sequential animations with subsequent animation methods executing after the previous method has completed. For more information, see Compound Animations.\n\nIf there's a requirement to let an animation complete in the background, then the await operator can be omitted. In this scenario, the animation extension methods will quickly return after initiating the animation, with the animation occurring in the background. This operation can be taken advantage of when creating composite animations";
        }

        public async Task Animate_Clicked(AnimationTypeModel model)
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
				case 8:
					await imageDisplay.TranslateTo(-50, 0, 1000);    // Move image left
					await imageDisplay.TranslateTo(-50, -50, 1000); // Move image up
					await imageDisplay.TranslateTo(50, 50, 2000);   // Move image diagonally down and right
					await imageDisplay.TranslateTo(0, 50, 1000);     // Move image left
					await imageDisplay.TranslateTo(0, 0, 1000);       // Move image up
					break;
				case 9:
					await imageDisplay.RotateTo(360, 4000);
					await imageDisplay.ScaleTo(1.5, 2000);
					await imageDisplay.ScaleTo(1, 2000);
					break;
				case 10:
					await Task.WhenAny<bool>
                    (
                      imageDisplay.RotateTo(360, 4000),
                      imageDisplay.ScaleTo(1.5, 2000)
                    );
					await imageDisplay.ScaleTo(1, 2000);
					break;
				case 11:
					uint duration = 10 * 60 * 1000;

					await Task.WhenAll(
					  imageDisplay.RotateTo(307 * 360, duration),
					  imageDisplay.RotateXTo(251 * 360, duration),
					  imageDisplay.RotateYTo(199 * 360, duration)
					);
					break;
            }
        }
    }
}
