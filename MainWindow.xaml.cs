using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Text.Json;

namespace Vampire_Builder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Character? charChosenCharacter = null;
        #region var_def
        //Integers defining the level of the powerups bought in the "POWER UP" section.
        int intPowerupMightLevel,
            intPowerupArmorLevel,
            intPowerupMaxHealthLevel,
            intPowerupRecoveryLevel,
            intPowerupCooldownLevel,
            intPowerupAreaLevel,
            intPowerupSpeedLevel,
            intPowerupDurationLevel,
            intPowerupAmountLevel,
            intPowerupMoveSpeedLevel,
            intPowerupMagnetLevel,
            intPowerupLuckLevel,
            intPowerupGrowthLevel,
            intPowerupGreedLevel,
            intPowerupCurseLevel,
            intPowerupRevivalLevel,
            intPowerupRerollLevel,
            intPowerupSkipLevel;

        //Values defining the final, applied value of attributes to the PC.
        int intMaxHealthFinalValue,
            intArmorFinalValue,
            intMoveSpeedFinalValue,
            intMightFinalValue,
            intAreaFinalValue,
            intSpeedFinalValue,
            intDurationFinalValue,
            intAmountFinalValue,
            intLuckFinalValue,
            intGrowthFinalValue,
            intGreedFinalValue,
            intCurseFinalValue,
            intMagnetFinalValue,
            intRevivalFinalValue,
            intRerollFinalValue,
            intSkipFinalValue;
        double dblRecoveryFinalValue,
            dblCooldownFinalValue;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            FillImages();
            GetCharactersFromJSON();
            //ResetInterface();
        }

        public void CalculateAttributes()
        {
            //TODO
            intMaxHealthFinalValue = 0 + (intPowerupMaxHealthLevel * 10);

            dblRecoveryFinalValue = 0 + (intPowerupRecoveryLevel * 0.1);

            intArmorFinalValue = 0 + (intPowerupArmorLevel * 1);

            intMoveSpeedFinalValue = 0 + (intPowerupMoveSpeedLevel * 5);

            intMightFinalValue = 0 + (intPowerupMightLevel * 5);

            intAreaFinalValue = 0 + (intPowerupAreaLevel * 5);

            intSpeedFinalValue = 0 + (intPowerupSpeedLevel * 10);

            intDurationFinalValue = 0 + (intPowerupDurationLevel * 15);

            intAmountFinalValue = 0 + (intPowerupAmountLevel * 1);

            dblCooldownFinalValue = 0 + (intPowerupCooldownLevel * 2.5);

            intLuckFinalValue = 0 + (intPowerupLuckLevel * 10);

            intGrowthFinalValue = 0 + (intPowerupGrowthLevel * 3);

            intGreedFinalValue = 0 + (intPowerupGreedLevel * 10);

            intCurseFinalValue = 0 + (intPowerupCurseLevel * 10);

            intMagnetFinalValue = 0 + (intPowerupMagnetLevel * 25);

            intRevivalFinalValue = 0 + (intPowerupRevivalLevel * 1);

            intRerollFinalValue = 0 + (intPowerupRerollLevel * 1);

            intSkipFinalValue = 0 + (intPowerupSkipLevel * 1);

            UpdateInterface();
        }

        private void UpdateInterface()
        {
            lblintMaxHealthFinalValue.Content = "" + intMaxHealthFinalValue;
            lbldblRecoveryFinalValue.Content = "" + dblRecoveryFinalValue;
            lblintArmorFinalValue.Content = "" + intArmorFinalValue;
            lblintMoveSpeedFinalValue.Content = "" + intMoveSpeedFinalValue;
            lblintMightFinalValue.Content = "" + intMightFinalValue;
            lblintAreaFinalValue.Content = "" + intAreaFinalValue;
            lblintSpeedFinalValue.Content = "" + intSpeedFinalValue;
            lblintDurationFinalValue.Content = "" + intDurationFinalValue;
            lblintAmountFinalValue.Content = "" + intAmountFinalValue;
            lbldblCooldownFinalValue.Content = "" + dblCooldownFinalValue;
            lblintLuckFinalValue.Content = "" + intLuckFinalValue;
            lblintGrowthFinalValue.Content = "" + intGrowthFinalValue;
            lblintGreedFinalValue.Content = "" + intGreedFinalValue;
            lblintCurseFinalValue.Content = "" + intCurseFinalValue;
            lblintMagnetFinalValue.Content = "" + intMagnetFinalValue;
            lblintRevivalFinalValue.Content = "" + intRevivalFinalValue;
            lblintRerollFinalValue.Content = "" + intRerollFinalValue;
            lblintSkipFinalValue.Content = "" + intSkipFinalValue;
        }

        private void FillImages()
        {
            BitmapImage bmpPowerupBackground = new BitmapImage(new Uri(@"res\Images\PowerUpBackground.png", UriKind.Relative));

            #region PowerUpSprites
            pngPowerupBackgroundMight.ImageSource = bmpPowerupBackground;
            pngItemSpinach.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Spinach.png", UriKind.Relative));

            pngPowerupBackgroundArmor.ImageSource = bmpPowerupBackground;
            pngItemArmor.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Armor.png", UriKind.Relative));

            pngPowerupBackgroundMaxHealth.ImageSource = bmpPowerupBackground;
            pngItemMaxHealth.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Hollow_Heart.png", UriKind.Relative));

            pngPowerupBackgroundRecovery.ImageSource = bmpPowerupBackground;
            pngItemRecovery.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Pummarola.png", UriKind.Relative));

            pngPowerupBackgroundCooldown.ImageSource = bmpPowerupBackground;
            pngItemCooldown.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Empty_Tome.png", UriKind.Relative));

            pngPowerupBackgroundArea.ImageSource = bmpPowerupBackground;
            pngItemArea.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Candelabrador.png", UriKind.Relative));

            pngPowerupBackgroundSpeed.ImageSource = bmpPowerupBackground;
            pngItemSpeed.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Bracer.png", UriKind.Relative));

            pngPowerupBackgroundDuration.ImageSource = bmpPowerupBackground;
            pngItemDuration.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Spellbinder.png", UriKind.Relative));

            pngPowerupBackgroundAmount.ImageSource = bmpPowerupBackground;
            pngItemAmount.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Duplicator.png", UriKind.Relative));

            pngPowerupBackgroundMoveSpeed.ImageSource = bmpPowerupBackground;
            pngItemMoveSpeed.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Wings.png", UriKind.Relative));

            pngPowerupBackgroundMagnet.ImageSource = bmpPowerupBackground;
            pngItemMagnet.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Attractorb.png", UriKind.Relative));

            pngPowerupBackgroundLuck.ImageSource = bmpPowerupBackground;
            pngItemLuck.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Clover.png", UriKind.Relative));

            pngPowerupBackgroundGrowth.ImageSource = bmpPowerupBackground;
            pngItemGrowth.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Crown.png", UriKind.Relative));

            pngPowerupBackgroundGreed.ImageSource = bmpPowerupBackground;
            pngItemGreed.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Stone_Mask.png", UriKind.Relative));

            pngPowerupBackgroundCurse.ImageSource = bmpPowerupBackground;
            pngItemCurse.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Skull_O'Maniac.png", UriKind.Relative));

            pngPowerupBackgroundRevival.ImageSource = bmpPowerupBackground;
            pngItemRevival.Source = new BitmapImage(new Uri(@"res\Items\Sprite-Tiragisu.png", UriKind.Relative));

            pngPowerupBackgroundReroll.ImageSource = bmpPowerupBackground;
            pngItemReroll.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Reroll.png", UriKind.Relative));

            pngPowerupBackgroundSkip.ImageSource = bmpPowerupBackground;
            pngItemSkip.Source = new BitmapImage(new Uri(@"res/Items/Sprite-Skip.png", UriKind.Relative));
            #endregion
            #region CharacterSelectSprites
            pngAntonio.Source = new BitmapImage(new Uri(@"res/Characters/Select-Antonio.png", UriKind.Relative));
            pngImelda.Source = new BitmapImage(new Uri(@"res/Characters/Select-Imelda.png", UriKind.Relative));
            pngPasqualina.Source = new BitmapImage(new Uri(@"res/Characters/Select-Pasqualina.png", UriKind.Relative));
            pngGennaro.Source = new BitmapImage(new Uri(@"res/Characters/Select-Gennaro.png", UriKind.Relative));
            pngArca.Source = new BitmapImage(new Uri(@"res/Characters/Select-Arca.png", UriKind.Relative));
            pngPorta.Source = new BitmapImage(new Uri(@"res/Characters/Select-Porta.png", UriKind.Relative));
            pngLama.Source = new BitmapImage(new Uri(@"res/Characters/Select-Lama.png", UriKind.Relative));
            pngPoe.Source = new BitmapImage(new Uri(@"res/Characters/Select-Poe.png", UriKind.Relative));
            pngClerici.Source = new BitmapImage(new Uri(@"res/Characters/Select-Clerici.png", UriKind.Relative));
            pngDommario.Source = new BitmapImage(new Uri(@"res/Characters/Select-Dommario.png", UriKind.Relative));
            pngKrochi.Source = new BitmapImage(new Uri(@"res/Characters/Select-Krochi.png", UriKind.Relative));
            pngChristine.Source = new BitmapImage(new Uri(@"res/Characters/Select-Christine.png", UriKind.Relative));
            pngPoppea.Source = new BitmapImage(new Uri(@"res/Characters/Select-Poppea.png", UriKind.Relative));
            pngMortaccio.Source = new BitmapImage(new Uri(@"res/Characters/Select-Mortaccio.png", UriKind.Relative));
            pngCavallo.Source = new BitmapImage(new Uri(@"res/Characters/Select-Cavallo.png", UriKind.Relative));
            pngExdash.Source = new BitmapImage(new Uri(@"res/Characters/Select-Exdash.png", UriKind.Relative));
            pngRed_Death.Source = new BitmapImage(new Uri(@"res/Characters/Select-Red_Death.png", UriKind.Relative));
            #endregion
        }

        private void ResetInterface()
        {
            //TODO charChosenCharacter = null;
        }

        private void GetCharactersFromJSON()
        {
            //TODO
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void btnResetAll_Click(object sender, RoutedEventArgs e)
        {
            btnResetItems_Click(sender, e);
            btnResetPowerUp_Click(sender, e);
        }

        private void btnResetPowerUp_Click(object sender, RoutedEventArgs e)
        {
            #region ResetPowerupLevels
            intPowerupMightLevel = 0;
            intPowerupArmorLevel = 0;
            intPowerupMaxHealthLevel = 0;
            intPowerupRecoveryLevel = 0;
            intPowerupCooldownLevel = 0;
            intPowerupAreaLevel = 0;
            intPowerupSpeedLevel = 0;
            intPowerupDurationLevel = 0;
            intPowerupAmountLevel = 0;
            intPowerupMoveSpeedLevel = 0;
            intPowerupMagnetLevel = 0;
            intPowerupLuckLevel = 0;
            intPowerupGrowthLevel = 0;
            intPowerupGreedLevel = 0;
            intPowerupCurseLevel = 0;
            intPowerupRevivalLevel = 0;
            intPowerupRerollLevel = 0;
            intPowerupSkipLevel = 0;
            #endregion
            #region ResetPowerupCheckboxes
            chkbxMight1.IsChecked = false;
            chkbxMight2.IsChecked = false;
            chkbxMight3.IsChecked = false;
            chkbxMight4.IsChecked = false;
            chkbxMight5.IsChecked = false;
            chkbxArmor1.IsChecked = false;
            chkbxArmor2.IsChecked = false;
            chkbxArmor3.IsChecked = false;
            chkbxMaxHealth1.IsChecked = false;
            chkbxMaxHealth2.IsChecked = false;
            chkbxMaxHealth3.IsChecked = false;
            chkbxRecovery1.IsChecked = false;
            chkbxRecovery2.IsChecked = false;
            chkbxRecovery3.IsChecked = false;
            chkbxRecovery4.IsChecked = false;
            chkbxRecovery5.IsChecked = false;
            chkbxCooldown1.IsChecked = false;
            chkbxCooldown2.IsChecked = false;
            chkbxArea1.IsChecked = false;
            chkbxArea2.IsChecked = false;
            chkbxSpeed1.IsChecked = false;
            chkbxSpeed2.IsChecked = false;
            chkbxDuration1.IsChecked = false;
            chkbxDuration2.IsChecked = false;
            chkbxAmount1.IsChecked = false;
            chkbxMoveSpeed1.IsChecked = false;
            chkbxMoveSpeed2.IsChecked = false;
            chkbxMagnet1.IsChecked = false;
            chkbxMagnet2.IsChecked = false;
            chkbxLuck1.IsChecked = false;
            chkbxLuck2.IsChecked = false;
            chkbxLuck3.IsChecked = false;
            chkbxGrowth1.IsChecked = false;
            chkbxGrowth2.IsChecked = false;
            chkbxGrowth3.IsChecked = false;
            chkbxGrowth4.IsChecked = false;
            chkbxGrowth5.IsChecked = false;
            chkbxGreed1.IsChecked = false;
            chkbxGreed2.IsChecked = false;
            chkbxGreed3.IsChecked = false;
            chkbxGreed4.IsChecked = false;
            chkbxGreed5.IsChecked = false;
            chkbxCurse1.IsChecked = false;
            chkbxCurse2.IsChecked = false;
            chkbxCurse3.IsChecked = false;
            chkbxCurse4.IsChecked = false;
            chkbxCurse5.IsChecked = false;
            chkbxRevival1.IsChecked = false;
            chkbxReroll1.IsChecked = false;
            chkbxReroll2.IsChecked = false;
            chkbxSkip1.IsChecked = false;
            chkbxSkip2.IsChecked = false;
            #endregion
            CalculateAttributes();
            UpdateInterface();
        }

        private void btnResetItems_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            CalculateAttributes();
            UpdateInterface();
        }

        private void btnActivateAllPowerups_Click(object sender, RoutedEventArgs e)
        {

            #region ActivatePowerupCheckboxes
            chkbxMight1.IsChecked = true;
            chkbxMight2.IsChecked = true;
            chkbxMight3.IsChecked = true;
            chkbxMight4.IsChecked = true;
            chkbxMight5.IsChecked = true;
            chkbxArmor1.IsChecked = true;
            chkbxArmor2.IsChecked = true;
            chkbxArmor3.IsChecked = true;
            chkbxMaxHealth1.IsChecked = true;
            chkbxMaxHealth2.IsChecked = true;
            chkbxMaxHealth3.IsChecked = true;
            chkbxRecovery1.IsChecked = true;
            chkbxRecovery2.IsChecked = true;
            chkbxRecovery3.IsChecked = true;
            chkbxRecovery4.IsChecked = true;
            chkbxRecovery5.IsChecked = true;
            chkbxCooldown1.IsChecked = true;
            chkbxCooldown2.IsChecked = true;
            chkbxArea1.IsChecked = true;
            chkbxArea2.IsChecked = true;
            chkbxSpeed1.IsChecked = true;
            chkbxSpeed2.IsChecked = true;
            chkbxDuration1.IsChecked = true;
            chkbxDuration2.IsChecked = true;
            chkbxAmount1.IsChecked = true;
            chkbxMoveSpeed1.IsChecked = true;
            chkbxMoveSpeed2.IsChecked = true;
            chkbxMagnet1.IsChecked = true;
            chkbxMagnet2.IsChecked = true;
            chkbxLuck1.IsChecked = true;
            chkbxLuck2.IsChecked = true;
            chkbxLuck3.IsChecked = true;
            chkbxGrowth1.IsChecked = true;
            chkbxGrowth2.IsChecked = true;
            chkbxGrowth3.IsChecked = true;
            chkbxGrowth4.IsChecked = true;
            chkbxGrowth5.IsChecked = true;
            chkbxGreed1.IsChecked = true;
            chkbxGreed2.IsChecked = true;
            chkbxGreed3.IsChecked = true;
            chkbxGreed4.IsChecked = true;
            chkbxGreed5.IsChecked = true;
            chkbxCurse1.IsChecked = true;
            chkbxCurse2.IsChecked = true;
            chkbxCurse3.IsChecked = true;
            chkbxCurse4.IsChecked = true;
            chkbxCurse5.IsChecked = true;
            chkbxRevival1.IsChecked = true;
            chkbxReroll1.IsChecked = true;
            chkbxReroll2.IsChecked = true;
            chkbxSkip1.IsChecked = true;
            chkbxSkip2.IsChecked = true;
            #endregion
        }

        #region Might_Checkboxes
        private void chkbxMight1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupMightLevel = 1;
            CalculateAttributes();
        }

        private void chkbxMight1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMight2.IsChecked = false;
            chkbxMight3.IsChecked = false;
            chkbxMight4.IsChecked = false;
            chkbxMight5.IsChecked = false;
            intPowerupMightLevel = 0;
            CalculateAttributes();

        }

        private void chkbxMight2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMight1.IsChecked = true;
            intPowerupMightLevel = 2;
            CalculateAttributes();

        }

        private void chkbxMight2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMight3.IsChecked = false;
            chkbxMight4.IsChecked = false;
            chkbxMight5.IsChecked = false;
            intPowerupMightLevel = 1;
            CalculateAttributes();
        }

        private void chkbxMight3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMight1.IsChecked = true;
            chkbxMight2.IsChecked = true;
            intPowerupMightLevel = 3;
            CalculateAttributes();
        }

        private void chkbxMight3_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMight4.IsChecked = false;
            chkbxMight5.IsChecked = false;
            intPowerupMightLevel = 2;
            CalculateAttributes();
        }

        private void chkbxMight4_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMight1.IsChecked = true;
            chkbxMight2.IsChecked = true;
            chkbxMight3.IsChecked = true;
            intPowerupMightLevel = 4;
            CalculateAttributes();
        }

        private void chkbxMight4_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMight5.IsChecked = false;
            intPowerupMightLevel = 3;
            CalculateAttributes();
        }

        private void chkbxMight5_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMight1.IsChecked = true;
            chkbxMight2.IsChecked = true;
            chkbxMight3.IsChecked = true;
            chkbxMight4.IsChecked = true;
            intPowerupMightLevel = 5;
            CalculateAttributes();
        }

        private void chkbxMight5_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupMightLevel = 4;
            CalculateAttributes();
        }
        #endregion
        #region Armor_Checkboxes
        private void chkbxArmor1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupArmorLevel = 1;
            CalculateAttributes();
        }

        private void chkbxArmor1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxArmor2.IsChecked = false;
            chkbxArmor3.IsChecked = false;
            intPowerupArmorLevel = 0;
            CalculateAttributes();

        }

        private void chkbxArmor2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxArmor1.IsChecked = true;
            intPowerupArmorLevel = 2;
            CalculateAttributes();

        }

        private void chkbxArmor2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxArmor3.IsChecked = false;
            intPowerupArmorLevel = 1;
            CalculateAttributes();
        }

        private void chkbxArmor3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxArmor1.IsChecked = true;
            chkbxArmor2.IsChecked = true;
            intPowerupArmorLevel = 3;
            CalculateAttributes();
        }

        private void chkbxArmor3_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupArmorLevel = 2;
            CalculateAttributes();
        }
        #endregion
        #region MaxHealth_Checkboxes
        private void chkbxMaxHealth1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupMaxHealthLevel = 1;
            CalculateAttributes();
        }

        private void chkbxMaxHealth1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMaxHealth2.IsChecked = false;
            chkbxMaxHealth3.IsChecked = false;
            intPowerupMaxHealthLevel = 0;
            CalculateAttributes();

        }

        private void chkbxMaxHealth2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMaxHealth1.IsChecked = true;
            intPowerupMaxHealthLevel = 2;
            CalculateAttributes();

        }

        private void chkbxMaxHealth2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMaxHealth3.IsChecked = false;
            intPowerupMaxHealthLevel = 1;
            CalculateAttributes();
        }

        private void chkbxMaxHealth3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMaxHealth1.IsChecked = true;
            chkbxMaxHealth2.IsChecked = true;
            intPowerupMaxHealthLevel = 3;
            CalculateAttributes();
        }

        private void chkbxMaxHealth3_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupMaxHealthLevel = 2;
            CalculateAttributes();
        }
        #endregion
        #region Recovery_Checkboxes
        private void chkbxRecovery1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupRecoveryLevel = 1;
            CalculateAttributes();
        }

        private void chkbxRecovery1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery2.IsChecked = false;
            chkbxRecovery3.IsChecked = false;
            chkbxRecovery4.IsChecked = false;
            chkbxRecovery5.IsChecked = false;
            intPowerupRecoveryLevel = 0;
            CalculateAttributes();
        }

        private void chkbxRecovery2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery1.IsChecked = true;
            intPowerupRecoveryLevel = 2;
            CalculateAttributes();
        }

        private void chkbxRecovery2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery3.IsChecked = false;
            chkbxRecovery4.IsChecked = false;
            chkbxRecovery5.IsChecked = false;
            intPowerupRecoveryLevel = 1;
            CalculateAttributes();
        }

        private void chkbxRecovery3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery1.IsChecked = true;
            chkbxRecovery2.IsChecked = true;
            intPowerupRecoveryLevel = 3;
            CalculateAttributes();
        }

        private void chkbxRecovery3_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery4.IsChecked = false;
            chkbxRecovery5.IsChecked = false;
            intPowerupRecoveryLevel = 2;
            CalculateAttributes();
        }

        private void chkbxRecovery4_Checked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery1.IsChecked = true;
            chkbxRecovery2.IsChecked = true;
            chkbxRecovery3.IsChecked = true;
            intPowerupRecoveryLevel = 4;
            CalculateAttributes();
        }

        private void chkbxRecovery4_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery5.IsChecked = false;
            intPowerupRecoveryLevel = 3;
            CalculateAttributes();
        }

        private void chkbxRecovery5_Checked(object sender, RoutedEventArgs e)
        {
            chkbxRecovery1.IsChecked = true;
            chkbxRecovery2.IsChecked = true;
            chkbxRecovery3.IsChecked = true;
            chkbxRecovery4.IsChecked = true;
            intPowerupRecoveryLevel = 5;
            CalculateAttributes();
        }

        private void chkbxRecovery5_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupRecoveryLevel = 4;
            CalculateAttributes();
        }
        #endregion
        #region Cooldown_Checkboxes
        private void chkbxCooldown1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupCooldownLevel = 1;
            CalculateAttributes();
        }

        private void chkbxCooldown1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxCooldown2.IsChecked = false;
            intPowerupCooldownLevel = 0;
            CalculateAttributes();
        }

        private void chkbxCooldown2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxCooldown1.IsChecked = true;
            intPowerupCooldownLevel = 2;
            CalculateAttributes();
        }

        private void chkbxCooldown2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupCooldownLevel = 1;
            CalculateAttributes();
        }
        #endregion
        #region Area_Checkboxes
        private void chkbxArea1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupAreaLevel = 1;
            CalculateAttributes();
        }

        private void chkbxArea1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxArea2.IsChecked = false;
            intPowerupAreaLevel = 0;
            CalculateAttributes();
        }

        private void chkbxArea2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxArea1.IsChecked = true;
            intPowerupAreaLevel = 2;
            CalculateAttributes();
        }

        private void chkbxArea2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupAreaLevel = 1;
            CalculateAttributes();
        }
        #endregion
        #region Speed_Checkboxes
        private void chkbxSpeed1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupSpeedLevel = 1;
            CalculateAttributes();
        }

        private void chkbxSpeed1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxSpeed2.IsChecked = false;
            intPowerupSpeedLevel = 0;
            CalculateAttributes();
        }

        private void chkbxSpeed2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxSpeed1.IsChecked = true;
            intPowerupSpeedLevel = 2;
            CalculateAttributes();
        }

        private void chkbxSpeed2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupSpeedLevel = 1;
            CalculateAttributes();
        }
        #endregion
        #region Duration_Checkboxes
        private void chkbxDuration1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupDurationLevel = 1;
            CalculateAttributes();
        }

        private void chkbxDuration1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxDuration2.IsChecked = false;
            intPowerupDurationLevel = 0;
            CalculateAttributes();
        }

        private void chkbxDuration2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxDuration1.IsChecked = true;
            intPowerupDurationLevel = 2;
            CalculateAttributes();
        }

        private void chkbxDuration2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupDurationLevel = 1;
            CalculateAttributes();
        }
        #endregion
        #region Amount_Checkboxes
        private void chkbxAmount1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupAmountLevel = 1;
            CalculateAttributes();
        }

        private void chkbxAmount1_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupAmountLevel = 0;
            CalculateAttributes();
        }
        #endregion
        #region MoveSpeed_Checkboxes
        private void chkbxMoveSpeed1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupMoveSpeedLevel = 1;
            CalculateAttributes();
        }

        private void chkbxMoveSpeed1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMoveSpeed2.IsChecked = false;
            intPowerupMoveSpeedLevel = 0;
            CalculateAttributes();
        }

        private void chkbxMoveSpeed2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMoveSpeed1.IsChecked = true;
            intPowerupMoveSpeedLevel = 2;
            CalculateAttributes();
        }

        private void chkbxMoveSpeed2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupMoveSpeedLevel = 1;
            CalculateAttributes();
        }
        #endregion
        #region Magnet_Checkboxes
        private void chkbxMagnet1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupMagnetLevel = 1;
            CalculateAttributes();
        }

        private void chkbxMagnet1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxMagnet2.IsChecked = false;
            intPowerupMagnetLevel = 0;
            CalculateAttributes();
        }

        private void chkbxMagnet2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxMagnet1.IsChecked = true;
            intPowerupMagnetLevel = 2;
            CalculateAttributes();
        }

        private void chkbxMagnet2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupMagnetLevel = 1;
            CalculateAttributes();
        }
        #endregion
        #region Luck_Checkboxes
        private void chkbxLuck1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupLuckLevel = 1;
            CalculateAttributes();
        }

        private void chkbxLuck1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxLuck2.IsChecked = false;
            intPowerupLuckLevel = 0;
            CalculateAttributes();
        }

        private void chkbxLuck2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxLuck1.IsChecked = true;
            intPowerupLuckLevel = 2;
            CalculateAttributes();
        }

        private void chkbxLuck2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxLuck3.IsChecked = false;
            intPowerupLuckLevel = 1;
            CalculateAttributes();
        }

        private void chkbxLuck3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxLuck1.IsChecked = true;
            chkbxLuck2.IsChecked = true;
            intPowerupLuckLevel = 3;
            CalculateAttributes();
        }

        private void chkbxLuck3_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupLuckLevel = 2;
            CalculateAttributes();
        }
        #endregion
        #region Growth_Checkboxes
        private void chkbxGrowth1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupGrowthLevel = 1;
            CalculateAttributes();
        }

        private void chkbxGrowth1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth2.IsChecked = false;
            chkbxGrowth3.IsChecked = false;
            chkbxGrowth4.IsChecked = false;
            chkbxGrowth5.IsChecked = false;
            intPowerupGrowthLevel = 0;
            CalculateAttributes();

        }

        private void chkbxGrowth2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth1.IsChecked = true;
            intPowerupGrowthLevel = 2;
            CalculateAttributes();

        }

        private void chkbxGrowth2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth3.IsChecked = false;
            chkbxGrowth4.IsChecked = false;
            chkbxGrowth5.IsChecked = false;
            intPowerupGrowthLevel = 1;
            CalculateAttributes();
        }

        private void chkbxGrowth3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth1.IsChecked = true;
            chkbxGrowth2.IsChecked = true;
            intPowerupGrowthLevel = 3;
            CalculateAttributes();
        }

        private void chkbxGrowth3_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth4.IsChecked = false;
            chkbxGrowth5.IsChecked = false;
            intPowerupGrowthLevel = 2;
            CalculateAttributes();
        }

        private void chkbxGrowth4_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth1.IsChecked = true;
            chkbxGrowth2.IsChecked = true;
            chkbxGrowth3.IsChecked = true;
            intPowerupGrowthLevel = 4;
            CalculateAttributes();
        }

        private void chkbxGrowth4_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth5.IsChecked = false;
            intPowerupGrowthLevel = 3;
            CalculateAttributes();
        }
        private void chkbxGrowth5_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGrowth1.IsChecked = true;
            chkbxGrowth2.IsChecked = true;
            chkbxGrowth3.IsChecked = true;
            chkbxGrowth4.IsChecked = true;
            intPowerupGrowthLevel = 5;
            CalculateAttributes();
        }

        private void chkbxGrowth5_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupGrowthLevel = 4;
            CalculateAttributes();
        }
        #endregion
        #region Greed_Checkboxes
        private void chkbxGreed1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupGreedLevel = 1;
            CalculateAttributes();
        }

        private void chkbxGreed1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGreed2.IsChecked = false;
            chkbxGreed3.IsChecked = false;
            chkbxGreed4.IsChecked = false;
            chkbxGreed5.IsChecked = false;
            intPowerupGreedLevel = 0;
            CalculateAttributes();

        }

        private void chkbxGreed2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGreed1.IsChecked = true;
            intPowerupGreedLevel = 2;
            CalculateAttributes();

        }

        private void chkbxGreed2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGreed3.IsChecked = false;
            chkbxGreed4.IsChecked = false;
            chkbxGreed5.IsChecked = false;
            intPowerupGreedLevel = 1;
            CalculateAttributes();
        }

        private void chkbxGreed3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGreed1.IsChecked = true;
            chkbxGreed2.IsChecked = true;
            intPowerupGreedLevel = 3;
            CalculateAttributes();
        }

        private void chkbxGreed3_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGreed4.IsChecked = false;
            chkbxGreed5.IsChecked = false;
            intPowerupGreedLevel = 2;
            CalculateAttributes();
        }

        private void chkbxGreed4_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGreed1.IsChecked = true;
            chkbxGreed2.IsChecked = true;
            chkbxGreed3.IsChecked = true;
            intPowerupGreedLevel = 4;
            CalculateAttributes();
        }

        private void chkbxGreed4_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxGreed5.IsChecked = false;
            intPowerupGreedLevel = 3;
            CalculateAttributes();
        }

        private void chkbxGreed5_Checked(object sender, RoutedEventArgs e)
        {
            chkbxGreed1.IsChecked = true;
            chkbxGreed2.IsChecked = true;
            chkbxGreed3.IsChecked = true;
            chkbxGreed4.IsChecked = true;
            intPowerupGreedLevel = 5;
            CalculateAttributes();
        }

        private void chkbxGreed5_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupGreedLevel = 4;
            CalculateAttributes();
        }
        #endregion
        #region Curse_Checkboxes
        private void chkbxCurse1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupCurseLevel = 1;
            CalculateAttributes();
        }

        private void chkbxCurse1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxCurse2.IsChecked = false;
            chkbxCurse3.IsChecked = false;
            chkbxCurse4.IsChecked = false;
            chkbxCurse5.IsChecked = false;
            intPowerupCurseLevel = 0;
            CalculateAttributes();

        }

        private void chkbxCurse2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxCurse1.IsChecked = true;
            intPowerupCurseLevel = 2;
            CalculateAttributes();

        }

        private void chkbxCurse2_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxCurse3.IsChecked = false;
            chkbxCurse4.IsChecked = false;
            chkbxCurse5.IsChecked = false;
            intPowerupCurseLevel = 1;
            CalculateAttributes();
        }

        private void chkbxCurse3_Checked(object sender, RoutedEventArgs e)
        {
            chkbxCurse1.IsChecked = true;
            chkbxCurse2.IsChecked = true;
            intPowerupCurseLevel = 3;
            CalculateAttributes();
        }

        private void chkbxCurse3_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxCurse4.IsChecked = false;
            chkbxCurse5.IsChecked = false;
            intPowerupCurseLevel = 2;
            CalculateAttributes();
        }

        private void chkbxCurse4_Checked(object sender, RoutedEventArgs e)
        {
            chkbxCurse1.IsChecked = true;
            chkbxCurse2.IsChecked = true;
            chkbxCurse3.IsChecked = true;
            intPowerupCurseLevel = 4;
            CalculateAttributes();
        }

        private void chkbxCurse4_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxCurse5.IsChecked = false;
            intPowerupCurseLevel = 3;
            CalculateAttributes();
        }

        private void chkbxCurse5_Checked(object sender, RoutedEventArgs e)
        {
            chkbxCurse1.IsChecked = true;
            chkbxCurse2.IsChecked = true;
            chkbxCurse3.IsChecked = true;
            chkbxCurse4.IsChecked = true;
            intPowerupCurseLevel = 5;
            CalculateAttributes();
        }

        private void chkbxCurse5_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupCurseLevel = 4;
            CalculateAttributes();
        }
        #endregion
        #region Revival_Checkboxes
        private void chkbxRevival1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupRevivalLevel = 1;
            CalculateAttributes();
        }

        private void chkbxRevival1_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupRevivalLevel = 0;
            CalculateAttributes();
        }
        #endregion
        #region Reroll_Checkboxes
        private void chkbxReroll1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupRerollLevel = 1;
            CalculateAttributes();
        }

        private void chkbxReroll1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxReroll2.IsChecked = false;
            intPowerupRerollLevel = 0;
            CalculateAttributes();
        }

        private void chkbxReroll2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxReroll1.IsChecked = true;
            intPowerupRerollLevel = 2;
            CalculateAttributes();
        }

        private void chkbxReroll2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupRerollLevel = 1;
            CalculateAttributes();
        }
        #endregion
        #region Skip_Checkboxes
        private void chkbxSkip1_Checked(object sender, RoutedEventArgs e)
        {
            intPowerupSkipLevel = 1;
            CalculateAttributes();
        }

        private void chkbxSkip1_Unchecked(object sender, RoutedEventArgs e)
        {
            chkbxSkip2.IsChecked = false;
            intPowerupSkipLevel = 0;
            CalculateAttributes();
        }

        private void chkbxSkip2_Checked(object sender, RoutedEventArgs e)
        {
            chkbxSkip1.IsChecked = true;
            intPowerupSkipLevel = 2;
            CalculateAttributes();
        }

        private void chkbxSkip2_Unchecked(object sender, RoutedEventArgs e)
        {
            intPowerupSkipLevel = 1;
            CalculateAttributes();
        }
        #endregion

        #region Characterselect
        private void btnAntonio(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void btnImelda(object sender, RoutedEventArgs e)
        {

        }

        private void btnPasqualina(object sender, RoutedEventArgs e)
        {

        }

        private void btnGennaro(object sender, RoutedEventArgs e)
        {

        }

        private void btnArca(object sender, RoutedEventArgs e)
        {

        }

        private void btnPorta(object sender, RoutedEventArgs e)
        {

        }

        private void btnLama(object sender, RoutedEventArgs e)
        {

        }

        private void btnPoe(object sender, RoutedEventArgs e)
        {

        }

        private void btnClerici(object sender, RoutedEventArgs e)
        {

        }

        private void btnDommario(object sender, RoutedEventArgs e)
        {

        }

        private void btnKrochi(object sender, RoutedEventArgs e)
        {

        }

        private void btnChristine(object sender, RoutedEventArgs e)
        {

        }

        private void btnPoppea(object sender, RoutedEventArgs e)
        {

        }

        private void btnMortaccio(object sender, RoutedEventArgs e)
        {

        }

        private void btnCavallo(object sender, RoutedEventArgs e)
        {

        }

        private void btnExdash(object sender, RoutedEventArgs e)
        {

        }

        private void btnRed_Death(object sender, RoutedEventArgs e)
        {

        }
        #endregion

    }
}
