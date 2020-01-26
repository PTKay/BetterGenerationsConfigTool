using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Generations_Launcher_Front.TextStore;

namespace Generations_Launcher_Front
{
	public class InputConfiguration : UserControl
	{
		public InputConfiguration()
		{
			this.InitializeComponent();
			this.mPadInfoList = new List<PadInfo>();
			this.mGuidPadInfoList = new List<PadInfo>();
			this.mButtonList = new List<ButtonConfig>();
			this.mMovementButtonList = new List<ButtonConfig>();
			this.mMovementButtonPairY = new List<ButtonConfig>();
			this.mMovementButtonPairX = new List<ButtonConfig>();
		}

		private void InputConfiguration_Load(object sender, EventArgs e)
		{
			this.InputUpdateTimer = new Timer();
			this.InputUpdateTimer.Tick += this.InputUpdateTimer_Tick;
			this.InputUpdateTimer.Interval = 100;
			this.InputUpdateTimer.Start();
			this.ResetTimer = new Timer();
			this.ResetTimer.Tick += this.ResetTimer_Tick;
			this.ResetTimer.Interval = 1500;
			ButtonConfig buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonA;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonX;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonY;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonB;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonStart;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonBack;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonLB;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonRB;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonLT;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonRT;
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonStickYU;
			this.mMovementButtonList.Add(buttonConfig);
			this.mMovementButtonPairY.Add(buttonConfig);
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonStickYD;
			this.mMovementButtonList.Add(buttonConfig);
			this.mMovementButtonPairY.Add(buttonConfig);
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonStickXR;
			this.mMovementButtonList.Add(buttonConfig);
			this.mMovementButtonPairX.Add(buttonConfig);
			this.mButtonList.Add(buttonConfig);
			buttonConfig = new ButtonConfig();
			buttonConfig.mButtonHandle = this.ButtonStickXL;
			this.mMovementButtonList.Add(buttonConfig);
			this.mMovementButtonPairX.Add(buttonConfig);
			this.mButtonList.Add(buttonConfig);
			this.InitControllerSelections();
			this.SetFormText();
		}

		private void SetFormText()
		{
			this.InputTypeLabel.Text = LocalizedText.InputTypeLabel;
			this.Instructions_label.Text = LocalizedText.Pad_Instructions;
			this.ResetDefaultButton.Text = LocalizedText.ResetDefaultButton;
			this.StartButtonInstructions_Label.Text = LocalizedText.SwitchPadInstruction_label;
		}

		private void InitControllerSelections()
		{
			int num = DllExterns._GetPadListCount();
			string b = "";
			if (this.InputType.SelectedIndex != -1)
			{
				PadInfo padInfo = (PadInfo)this.InputType.Items[this.InputType.SelectedIndex];
				b = padInfo.mProductName;
			}
			GlobalDefs globalDefs = new GlobalDefs();
			this.mPadInfoList.Clear();
			this.mGuidPadInfoList.Clear();
			DllExterns._FoundXInput(ref this.Found360Pad);
			if (this.Found360Pad)
			{
				this.mPadInfoList.Capacity = num + 1;
				this.mGuidPadInfoList.Capacity = num + 2;
				PadInfo padInfo2 = new PadInfo();
				padInfo2.mProductGuid = globalDefs.ZERO_GUID;
				padInfo2.mInstanceGuid = globalDefs.ZERO_GUID;
				padInfo2.mPadType = PadInfo.PAD_TYPE.PAD_TYPE_XBOX;
				padInfo2.mInstanceID = 0;
				padInfo2.mProductName = LocalizedText.Xbox_Pad_Name;
				this.mGuidPadInfoList.Add(padInfo2);
			}
			else
			{
				this.mPadInfoList.Capacity = num + 1;
				this.mGuidPadInfoList.Capacity = num + 1;
			}
			PadInfo padInfo3 = new PadInfo();
			padInfo3.mProductGuid = globalDefs.KEYBOARD_GUID;
			padInfo3.mInstanceGuid = globalDefs.ZERO_GUID;
			padInfo3.mPadType = PadInfo.PAD_TYPE.PAD_TYPE_KEYBOARD;
			padInfo3.mInstanceID = 0;
			padInfo3.mProductName = LocalizedText.Keyboard_Name;
			this.mPadInfoList.Add(padInfo3);
			this.mGuidPadInfoList.Add(padInfo3);
			int num2 = 1;
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				PadInfo padInfo4 = new PadInfo();
				DllExterns._GetPadInfo(padInfo4, i);
				this.mPadInfoList.Add(padInfo4);
				foreach (PadInfo padInfo5 in this.mGuidPadInfoList)
				{
					if (padInfo5.mProductGuid == padInfo4.mProductGuid)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					this.mGuidPadInfoList.Add(padInfo4);
					num2++;
				}
			}
			this.InputType.DataSource = null;
			this.InputType.Items.Clear();
			this.InputType.DataSource = this.mGuidPadInfoList;
			this.InputType.DisplayMember = "DisplayName";
			this.InputType.SelectedIndex = 0;
			this.UpdateConfigList();
			int num3 = 0;
			foreach (object obj in this.InputType.Items)
			{
				PadInfo padInfo6 = (PadInfo)obj;
				if (padInfo6.mProductName == b)
				{
					this.InputType.SelectedIndex = num3;
					break;
				}
				num3++;
			}
		}

		public void UpdateConfigList()
		{
			if (GlobalDefs.OutputConfigList.Count<OutputConfig>() > 0)
			{
				using (List<PadInfo>.Enumerator enumerator = this.mGuidPadInfoList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						PadInfo padInfo = enumerator.Current;
						bool flag = false;
						foreach (OutputConfig outputConfig in GlobalDefs.OutputConfigList)
						{
							if (outputConfig.mProductGuid == padInfo.mProductGuid)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							OutputConfig outputConfig2 = new OutputConfig();
							outputConfig2.mProductGuid = padInfo.mProductGuid;
							outputConfig2.mProductName = padInfo.mProductName;
							GlobalDefs.OutputConfigList.Add(outputConfig2);
							Console.WriteLine("Added To Config List : " + outputConfig2.mProductName);
						}
					}
					return;
				}
			}
			foreach (PadInfo padInfo2 in this.mGuidPadInfoList)
			{
				OutputConfig outputConfig3 = new OutputConfig();
				outputConfig3.mProductGuid = padInfo2.mProductGuid;
				outputConfig3.mProductName = padInfo2.mProductName;
				GlobalDefs.OutputConfigList.Add(outputConfig3);
			}
			foreach (OutputConfig outputConfig4 in GlobalDefs.OutputConfigList)
			{
				Console.WriteLine("Added To Config List : " + outputConfig4.mProductName);
			}
		}

		private void Button_Hover(object sender, EventArgs e)
		{
			this.ActiveButton = (Button)sender;
			this.ActiveButton.Focus();
		}

		private void Button_HoverLeave(object sender, EventArgs e)
		{
			this.ActiveButton = null;
		}

		private void InputUpdateTimer_Tick(object sender, EventArgs e)
		{
			if (this.bRefreshButtons)
			{
				this.RefreshButtons();
			}
			if (this.ActiveButton != null)
			{
				PadInfo padInfo = (PadInfo)this.InputType.Items[this.InputType.SelectedIndex];
				switch (padInfo.mPadType)
				{
				case PadInfo.PAD_TYPE.PAD_TYPE_LEGACY:
					if (DllExterns._PollPad())
					{
						sPressInfo sPressInfo = new sPressInfo();
						DllExterns._GetPadPressInfo(sPressInfo, padInfo.mInstanceID);
						if (sPressInfo.m_Type == sPressInfo.PressType.PT_None)
						{
							foreach (PadInfo padInfo2 in this.mPadInfoList)
							{
								if (padInfo.mInstanceID != padInfo2.mInstanceID && padInfo.mProductGuid == padInfo2.mProductGuid)
								{
									DllExterns._GetPadPressInfo(sPressInfo, padInfo2.mInstanceID);
									if (sPressInfo.m_Type != sPressInfo.PressType.PT_None)
									{
										break;
									}
								}
							}
						}
						if (sPressInfo.m_Type != sPressInfo.PressType.PT_None)
						{
							switch (sPressInfo.m_Type)
							{
							case sPressInfo.PressType.PT_Axis:
							case sPressInfo.PressType.PT_Rotation:
								break;
							case sPressInfo.PressType.PT_Slider:
								goto IL_84E;
							case sPressInfo.PressType.PT_Pov:
								goto IL_7B6;
							case sPressInfo.PressType.PT_Button:
								foreach (ButtonConfig buttonConfig in this.mMovementButtonList)
								{
									if (buttonConfig.mButtonHandle == this.ActiveButton)
									{
										if (this.MovementInputType != 2)
										{
											foreach (ButtonConfig buttonConfig2 in this.mMovementButtonList)
											{
												if (buttonConfig2.mButtonHandle != this.ActiveButton)
												{
													buttonConfig2.Reset();
													buttonConfig2.mButtonHandle.Text = LocalizedText.Undefined;
												}
											}
										}
										this.MovementInputType = 2;
									}
								}
								using (List<ButtonConfig>.Enumerator enumerator4 = this.mButtonList.GetEnumerator())
								{
									while (enumerator4.MoveNext())
									{
										ButtonConfig buttonConfig3 = enumerator4.Current;
										if (buttonConfig3.mButtonHandle == this.ActiveButton)
										{
											buttonConfig3.Reset();
											buttonConfig3.mPressInfo = sPressInfo;
											sPressInfo mPressInfo = buttonConfig3.mPressInfo;
											mPressInfo.m_Index += 1;
											buttonConfig3.mButtonHandle.Text = "Button " + buttonConfig3.mPressInfo.m_Index;
											foreach (ButtonConfig buttonConfig4 in this.mButtonList)
											{
												if (buttonConfig4 != buttonConfig3 && buttonConfig4.mPressInfo.m_Type == buttonConfig3.mPressInfo.m_Type && buttonConfig4.mPressInfo.m_Index == buttonConfig3.mPressInfo.m_Index)
												{
													buttonConfig4.Reset();
													buttonConfig4.mButtonHandle.Text = LocalizedText.Undefined;
												}
											}
										}
									}
									goto IL_84E;
								}
								break;
							default:
								goto IL_84E;
							}
							bool flag = false;
							foreach (ButtonConfig buttonConfig5 in this.mMovementButtonPairY)
							{
								if (buttonConfig5.mButtonHandle == this.ActiveButton)
								{
									if (this.MovementInputType != 1)
									{
										foreach (ButtonConfig buttonConfig6 in this.mMovementButtonList)
										{
											buttonConfig6.Reset();
											buttonConfig6.mButtonHandle.Text = LocalizedText.Undefined;
										}
									}
									this.MovementInputType = 1;
									flag = true;
								}
							}
							if (flag)
							{
								byte b = sPressInfo.m_Index;
								if (sPressInfo.m_Type == sPressInfo.PressType.PT_Rotation)
								{
									b = 4;
								}
								else
								{
									b += 1;
								}
								foreach (ButtonConfig buttonConfig7 in this.mMovementButtonPairY)
								{
									buttonConfig7.Reset();
									buttonConfig7.mButtonHandle.Text = sPressInfo.m_tszName;
									buttonConfig7.mPressInfo = sPressInfo;
									buttonConfig7.mPressInfo.m_Index = b;
								}
								if (this.mMovementButtonPairX[0].mPressInfo.m_Type != sPressInfo.m_Type || this.mMovementButtonPairX[0].mPressInfo.m_Index != b)
								{
									goto IL_84E;
								}
								using (List<ButtonConfig>.Enumerator enumerator9 = this.mMovementButtonPairX.GetEnumerator())
								{
									while (enumerator9.MoveNext())
									{
										ButtonConfig buttonConfig8 = enumerator9.Current;
										buttonConfig8.Reset();
										buttonConfig8.mButtonHandle.Text = LocalizedText.Undefined;
									}
									goto IL_84E;
								}
							}
							foreach (ButtonConfig buttonConfig9 in this.mMovementButtonPairX)
							{
								if (buttonConfig9.mButtonHandle == this.ActiveButton)
								{
									if (this.MovementInputType != 1)
									{
										foreach (ButtonConfig buttonConfig10 in this.mMovementButtonList)
										{
											buttonConfig10.Reset();
											buttonConfig10.mButtonHandle.Text = LocalizedText.Undefined;
										}
									}
									this.MovementInputType = 1;
									flag = true;
								}
							}
							if (!flag)
							{
								goto IL_84E;
							}
							byte b2 = sPressInfo.m_Index;
							if (sPressInfo.m_Type == sPressInfo.PressType.PT_Rotation)
							{
								b2 = 4;
							}
							else
							{
								b2 += 1;
							}
							foreach (ButtonConfig buttonConfig11 in this.mMovementButtonPairX)
							{
								buttonConfig11.Reset();
								buttonConfig11.mButtonHandle.Text = sPressInfo.m_tszName;
								buttonConfig11.mPressInfo = sPressInfo;
								buttonConfig11.mPressInfo.m_Index = b2;
							}
							if (this.mMovementButtonPairY[0].mPressInfo.m_Type != sPressInfo.m_Type || this.mMovementButtonPairY[0].mPressInfo.m_Index != b2)
							{
								goto IL_84E;
							}
							using (List<ButtonConfig>.Enumerator enumerator13 = this.mMovementButtonPairY.GetEnumerator())
							{
								while (enumerator13.MoveNext())
								{
									ButtonConfig buttonConfig12 = enumerator13.Current;
									buttonConfig12.Reset();
									buttonConfig12.mButtonHandle.Text = LocalizedText.Undefined;
								}
								goto IL_84E;
							}
							IL_7B6:
							foreach (ButtonConfig buttonConfig13 in this.mMovementButtonList)
							{
								if (buttonConfig13.mButtonHandle == this.ActiveButton)
								{
									if (this.MovementInputType != 0)
									{
										foreach (ButtonConfig buttonConfig14 in this.mMovementButtonList)
										{
											buttonConfig14.Reset();
											buttonConfig14.mButtonHandle.Text = "D-Pad";
										}
									}
									this.MovementInputType = 0;
								}
							}
							IL_84E:
							this.UpdateButtonConfiguration();
						}
					}
					break;
				case PadInfo.PAD_TYPE.PAD_TYPE_KEYBOARD:
					if (DllExterns._PollKeyboard())
					{
						int num = DllExterns._GetKeyboardPressed();
						if (num != -1)
						{
							foreach (ButtonConfig buttonConfig15 in this.mButtonList)
							{
								if (buttonConfig15.mButtonHandle == this.ActiveButton)
								{
									buttonConfig15.Reset();
									buttonConfig15.mKeyboardKey = (uint)num;
									int num2 = num;
									if (num2 != 200)
									{
										switch (num2)
										{
										case 203:
											buttonConfig15.mButtonHandle.Text = "Left";
											goto IL_148;
										case 204:
											break;
										case 205:
											buttonConfig15.mButtonHandle.Text = "Right";
											goto IL_148;
										default:
											if (num2 == 208)
											{
												buttonConfig15.mButtonHandle.Text = "Down";
												goto IL_148;
											}
											break;
										}
										buttonConfig15.mButtonHandle.Text = Enum.Parse(typeof(Keys), DllExterns._GetKeyboardPressedAscii().ToString()).ToString();
									}
									else
									{
										buttonConfig15.mButtonHandle.Text = "Up";
									}
									IL_148:
									foreach (ButtonConfig buttonConfig16 in this.mButtonList)
									{
										if (buttonConfig16 != buttonConfig15 && buttonConfig16.mKeyboardKey == buttonConfig15.mKeyboardKey)
										{
											buttonConfig16.Reset();
											buttonConfig16.mButtonHandle.Text = LocalizedText.Undefined;
										}
									}
								}
							}
							this.UpdateButtonConfiguration();
							return;
						}
					}
					break;
				default:
					return;
				}
			}
		}

		public void UpdateButtonConfiguration()
		{
			PadInfo padInfo = (PadInfo)this.InputType.Items[this.InputType.SelectedIndex];
			switch (padInfo.mPadType)
			{
			case PadInfo.PAD_TYPE.PAD_TYPE_LEGACY:
				break;
			case PadInfo.PAD_TYPE.PAD_TYPE_KEYBOARD:
				using (List<OutputConfig>.Enumerator enumerator = GlobalDefs.OutputConfigList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						OutputConfig outputConfig = enumerator.Current;
						if (outputConfig.mProductGuid == padInfo.mProductGuid)
						{
							int num = 0;
							outputConfig.mMovementType = 2;
							foreach (ButtonConfig buttonConfig in this.mButtonList)
							{
								outputConfig.mButtonMap[num] = (int)buttonConfig.mKeyboardKey;
								num++;
								if (num >= outputConfig.mButtonMap.Length)
								{
									break;
								}
							}
						}
					}
					return;
				}
				break;
			default:
				return;
			}
			foreach (OutputConfig outputConfig2 in GlobalDefs.OutputConfigList)
			{
				if (outputConfig2.mProductGuid == padInfo.mProductGuid)
				{
					outputConfig2.mMovementType = this.MovementInputType;
					for (int i = 0; i < outputConfig2.mButtonMap.Count<int>(); i++)
					{
						outputConfig2.mButtonMap[i] = 0;
					}
					for (int j = 0; j < outputConfig2.mAxisMap.Count<int>(); j++)
					{
						outputConfig2.mAxisMap[j] = 0;
					}
					int num2 = 0;
					foreach (ButtonConfig buttonConfig2 in this.mButtonList)
					{
						if (num2 < outputConfig2.mButtonMap.Length)
						{
							outputConfig2.mButtonMap[num2] = (int)buttonConfig2.mPressInfo.m_Index;
							num2++;
						}
					}
					int num3 = 0;
					foreach (ButtonConfig buttonConfig3 in this.mMovementButtonList)
					{
						if (num3 < outputConfig2.mAxisMap.Length)
						{
							outputConfig2.mAxisMap[num3] = (int)buttonConfig3.mPressInfo.m_Index;
							num3++;
						}
					}
				}
			}
		}

		public void RefreshButtons()
		{
			foreach (ButtonConfig buttonConfig in this.mButtonList)
			{
				buttonConfig.Reset();
			}
			OutputConfig outputConfig = null;
			PadInfo padInfo = (PadInfo)this.InputType.Items[this.InputType.SelectedIndex];
			GlobalDefs globalDefs = new GlobalDefs();
			if (padInfo.mPadType == PadInfo.PAD_TYPE.PAD_TYPE_XBOX || padInfo.mProductGuid == globalDefs.ZERO_GUID)
			{
				this.ResetDefaultButton.Enabled = false;
				this.ResetDefaultButton.Visible = false;
				this.Instructions_label.Visible = false;
				foreach (ButtonConfig buttonConfig2 in this.mButtonList)
				{
					buttonConfig2.mButtonHandle.Enabled = false;
					buttonConfig2.mButtonHandle.Visible = false;
				}
				this.pictureBox1.Visible = false;
			}
			else
			{
				this.ResetDefaultButton.Enabled = true;
				this.ResetDefaultButton.Visible = true;
				this.Instructions_label.Visible = true;
				foreach (ButtonConfig buttonConfig3 in this.mButtonList)
				{
					buttonConfig3.mButtonHandle.Enabled = true;
					buttonConfig3.mButtonHandle.Visible = true;
				}
				this.pictureBox1.Visible = true;
			}
			foreach (OutputConfig outputConfig2 in GlobalDefs.OutputConfigList)
			{
				if (padInfo.mProductGuid == outputConfig2.mProductGuid)
				{
					outputConfig = outputConfig2;
					break;
				}
			}
			if (outputConfig != null)
			{
				this.bRefreshButtons = false;
				int num;
				switch (padInfo.mPadType)
				{
				case PadInfo.PAD_TYPE.PAD_TYPE_LEGACY:
					break;
				case PadInfo.PAD_TYPE.PAD_TYPE_KEYBOARD:
					foreach (ButtonConfig buttonConfig4 in this.mMovementButtonList)
					{
						buttonConfig4.Reset();
					}
					this.MovementInputType = outputConfig.mMovementType;
					num = 0;
					using (List<ButtonConfig>.Enumerator enumerator6 = this.mButtonList.GetEnumerator())
					{
						while (enumerator6.MoveNext())
						{
							ButtonConfig buttonConfig5 = enumerator6.Current;
							buttonConfig5.Reset();
							uint num2 = (uint)outputConfig.mButtonMap[num];
							if (num2 != 0u)
							{
								buttonConfig5.mKeyboardKey = (uint)outputConfig.mButtonMap[num];
								uint mKeyboardKey = buttonConfig5.mKeyboardKey;
								if (mKeyboardKey != 200u)
								{
									switch (mKeyboardKey)
									{
									case 203u:
										buttonConfig5.mButtonHandle.Text = LocalizedText.Keyboard_Left;
										goto IL_324;
									case 204u:
										break;
									case 205u:
										buttonConfig5.mButtonHandle.Text = LocalizedText.Keyboard_Right;
										goto IL_324;
									default:
										if (mKeyboardKey == 208u)
										{
											buttonConfig5.mButtonHandle.Text = LocalizedText.Keyboard_Down;
											goto IL_324;
										}
										break;
									}
									buttonConfig5.mButtonHandle.Text = Enum.Parse(typeof(Keys), DllExterns._ConvertToAscii((int)buttonConfig5.mKeyboardKey).ToString()).ToString();
								}
								else
								{
									buttonConfig5.mButtonHandle.Text = LocalizedText.Keyboard_Up;
								}
							}
							IL_324:
							num++;
							if (num >= outputConfig.mButtonMap.Length)
							{
								break;
							}
						}
						return;
					}
					break;
				default:
					return;
				}
				this.MovementInputType = outputConfig.mMovementType;
				num = 0;
				foreach (ButtonConfig buttonConfig6 in this.mButtonList)
				{
					buttonConfig6.Reset();
					uint num3 = (uint)outputConfig.mButtonMap[num];
					if (num3 != 0u)
					{
						buttonConfig6.mPressInfo.m_Index = (byte)num3;
						buttonConfig6.mPressInfo.m_Type = sPressInfo.PressType.PT_Button;
						buttonConfig6.mButtonHandle.Text = "Button " + num3;
					}
					num++;
					if (num >= outputConfig.mButtonMap.Length)
					{
						break;
					}
				}
				switch (this.MovementInputType)
				{
				case 0:
					using (List<ButtonConfig>.Enumerator enumerator8 = this.mMovementButtonList.GetEnumerator())
					{
						while (enumerator8.MoveNext())
						{
							ButtonConfig buttonConfig7 = enumerator8.Current;
							buttonConfig7.Reset();
							buttonConfig7.mButtonHandle.Text = "D-Pad";
						}
						return;
					}
					break;
				case 1:
					break;
				case 2:
					return;
				default:
					return;
				}
				num = 0;
				foreach (ButtonConfig buttonConfig8 in this.mMovementButtonList)
				{
					buttonConfig8.Reset();
					uint num4 = (uint)outputConfig.mAxisMap[num];
					if (num4 != 0u)
					{
						buttonConfig8.mPressInfo.m_Index = (byte)num4;
						buttonConfig8.mPressInfo.m_Type = sPressInfo.PressType.PT_Axis;
						switch (num4)
						{
						case 1u:
							buttonConfig8.mButtonHandle.Text = "X Axis";
							buttonConfig8.mPressInfo.m_tszName = "X Axis";
							break;
						case 2u:
							buttonConfig8.mButtonHandle.Text = "Y Axis";
							buttonConfig8.mPressInfo.m_tszName = "Y Axis";
							break;
						case 3u:
							buttonConfig8.mButtonHandle.Text = "Z Axis";
							buttonConfig8.mPressInfo.m_tszName = "Z Axis";
							break;
						case 4u:
							buttonConfig8.mButtonHandle.Text = "Z Rotation";
							buttonConfig8.mPressInfo.m_tszName = "Z Rotation";
							buttonConfig8.mPressInfo.m_Type = sPressInfo.PressType.PT_Rotation;
							break;
						}
					}
					num++;
					if (num >= outputConfig.mAxisMap.Length)
					{
						break;
					}
				}
			}
		}

		private void ResetTimer_Tick(object sender, EventArgs e)
		{
			this.InputUpdateTimer.Stop();
			this.ResetTimer.Stop();
			DllExterns._ResetPadLists();
			this.InitControllerSelections();
			this.InputUpdateTimer.Start();
		}

		public void ResetPadListData()
		{
			if (!this.ResetTimer.Enabled)
			{
				this.ResetTimer.Start();
			}
		}

		private void InputType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.bRefreshButtons = true;
		}

		private void ButtonStickLX_Click(object sender, EventArgs e)
		{
		}

		private void InputType_KeyDown(object sender, KeyEventArgs e)
		{
			e.SuppressKeyPress = true;
		}

		private void ResetDefaultButton_Click(object sender, EventArgs e)
		{
			int num = 0;
			string text = "DefaultInput.cfg";
			if (File.Exists(text))
			{
				PadInfo padInfo = (PadInfo)this.InputType.Items[this.InputType.SelectedIndex];
				foreach (OutputConfig outputConfig in GlobalDefs.OutputConfigList)
				{
					if (padInfo.mProductGuid == outputConfig.mProductGuid)
					{
						FileHandler.LoadInfoConfig(text, num);
						break;
					}
					num++;
				}
				this.RefreshButtons();
				return;
			}
			MessageBox.Show(LocalizedText.DefaultInputMissing, LocalizedText.Error, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(InputConfiguration));
			this.ButtonA = new Button();
			this.ButtonB = new Button();
			this.InputType = new ComboBox();
			this.InputTypeLabel = new Label();
			this.ButtonX = new Button();
			this.ButtonY = new Button();
			this.ButtonRB = new Button();
			this.ButtonLB = new Button();
			this.ButtonBack = new Button();
			this.ButtonStart = new Button();
			this.ButtonLT = new Button();
			this.ButtonRT = new Button();
			this.ButtonStickYD = new Button();
			this.ButtonStickXL = new Button();
			this.ButtonStickYU = new Button();
			this.ButtonStickXR = new Button();
			this.ResetDefaultButton = new Button();
			this.pictureBox1 = new PictureBox();
			this.Instructions_label = new Label();
			this.pictureBox2 = new PictureBox();
			this.StartButtonInstructions_Label = new Label();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.ButtonA.Location = new Point(703, 316);
			this.ButtonA.Name = "ButtonA";
			this.ButtonA.Size = new Size(73, 36);
			this.ButtonA.TabIndex = 1;
			this.ButtonA.Text = "button1";
			this.ButtonA.UseVisualStyleBackColor = true;
			this.ButtonA.Visible = false;
			this.ButtonA.MouseLeave += this.Button_HoverLeave;
			this.ButtonA.MouseHover += this.Button_Hover;
			this.ButtonB.Location = new Point(750, 270);
			this.ButtonB.Name = "ButtonB";
			this.ButtonB.Size = new Size(73, 36);
			this.ButtonB.TabIndex = 2;
			this.ButtonB.Text = "button2";
			this.ButtonB.UseVisualStyleBackColor = true;
			this.ButtonB.Visible = false;
			this.ButtonB.MouseLeave += this.Button_HoverLeave;
			this.ButtonB.MouseHover += this.Button_Hover;
			this.InputType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.InputType.FormattingEnabled = true;
			this.InputType.Location = new Point(3, 28);
			this.InputType.Name = "InputType";
			this.InputType.Size = new Size(840, 21);
			this.InputType.TabIndex = 3;
			this.InputType.SelectedIndexChanged += this.InputType_SelectedIndexChanged;
			this.InputType.KeyDown += this.InputType_KeyDown;
			this.InputTypeLabel.Location = new Point(3, 9);
			this.InputTypeLabel.Name = "InputTypeLabel";
			this.InputTypeLabel.Size = new Size(840, 16);
			this.InputTypeLabel.TabIndex = 4;
			this.InputTypeLabel.Text = "label1";
			this.InputTypeLabel.TextAlign = ContentAlignment.BottomLeft;
			this.ButtonX.Location = new Point(660, 271);
			this.ButtonX.Name = "ButtonX";
			this.ButtonX.Size = new Size(73, 36);
			this.ButtonX.TabIndex = 5;
			this.ButtonX.Text = "button1";
			this.ButtonX.UseVisualStyleBackColor = true;
			this.ButtonX.Visible = false;
			this.ButtonX.MouseLeave += this.Button_HoverLeave;
			this.ButtonX.MouseHover += this.Button_Hover;
			this.ButtonY.Location = new Point(703, 224);
			this.ButtonY.Name = "ButtonY";
			this.ButtonY.Size = new Size(73, 36);
			this.ButtonY.TabIndex = 6;
			this.ButtonY.Text = "button1";
			this.ButtonY.UseVisualStyleBackColor = true;
			this.ButtonY.Visible = false;
			this.ButtonY.MouseLeave += this.Button_HoverLeave;
			this.ButtonY.MouseHover += this.Button_Hover;
			this.ButtonRB.Location = new Point(641, 141);
			this.ButtonRB.Name = "ButtonRB";
			this.ButtonRB.Size = new Size(73, 36);
			this.ButtonRB.TabIndex = 10;
			this.ButtonRB.Text = "button1";
			this.ButtonRB.UseVisualStyleBackColor = true;
			this.ButtonRB.Visible = false;
			this.ButtonRB.MouseLeave += this.Button_HoverLeave;
			this.ButtonRB.MouseHover += this.Button_Hover;
			this.ButtonLB.Location = new Point(136, 141);
			this.ButtonLB.Name = "ButtonLB";
			this.ButtonLB.Size = new Size(73, 36);
			this.ButtonLB.TabIndex = 9;
			this.ButtonLB.Text = "button1";
			this.ButtonLB.UseVisualStyleBackColor = true;
			this.ButtonLB.Visible = false;
			this.ButtonLB.MouseLeave += this.Button_HoverLeave;
			this.ButtonLB.MouseHover += this.Button_Hover;
			this.ButtonBack.Location = new Point(343, 81);
			this.ButtonBack.Name = "ButtonBack";
			this.ButtonBack.Size = new Size(73, 36);
			this.ButtonBack.TabIndex = 8;
			this.ButtonBack.Text = "button2";
			this.ButtonBack.UseVisualStyleBackColor = true;
			this.ButtonBack.Visible = false;
			this.ButtonBack.MouseLeave += this.Button_HoverLeave;
			this.ButtonBack.MouseHover += this.Button_Hover;
			this.ButtonStart.Location = new Point(432, 81);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new Size(73, 36);
			this.ButtonStart.TabIndex = 7;
			this.ButtonStart.Text = "button1";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Visible = false;
			this.ButtonStart.MouseLeave += this.Button_HoverLeave;
			this.ButtonStart.MouseHover += this.Button_Hover;
			this.ButtonLT.Location = new Point(136, 97);
			this.ButtonLT.Name = "ButtonLT";
			this.ButtonLT.Size = new Size(73, 36);
			this.ButtonLT.TabIndex = 12;
			this.ButtonLT.Text = "ButtonLT";
			this.ButtonLT.UseVisualStyleBackColor = true;
			this.ButtonLT.Visible = false;
			this.ButtonLT.MouseLeave += this.Button_HoverLeave;
			this.ButtonLT.MouseHover += this.Button_Hover;
			this.ButtonRT.Location = new Point(641, 98);
			this.ButtonRT.Name = "ButtonRT";
			this.ButtonRT.Size = new Size(73, 36);
			this.ButtonRT.TabIndex = 11;
			this.ButtonRT.Text = "ButtonRT";
			this.ButtonRT.UseVisualStyleBackColor = true;
			this.ButtonRT.Visible = false;
			this.ButtonRT.MouseLeave += this.Button_HoverLeave;
			this.ButtonRT.MouseHover += this.Button_Hover;
			this.ButtonStickYD.Location = new Point(72, 316);
			this.ButtonStickYD.Name = "ButtonStickYD";
			this.ButtonStickYD.Size = new Size(73, 36);
			this.ButtonStickYD.TabIndex = 16;
			this.ButtonStickYD.Text = "button3";
			this.ButtonStickYD.UseVisualStyleBackColor = true;
			this.ButtonStickYD.Visible = false;
			this.ButtonStickYD.MouseLeave += this.Button_HoverLeave;
			this.ButtonStickYD.MouseHover += this.Button_Hover;
			this.ButtonStickXL.Location = new Point(29, 270);
			this.ButtonStickXL.Name = "ButtonStickXL";
			this.ButtonStickXL.Size = new Size(73, 36);
			this.ButtonStickXL.TabIndex = 15;
			this.ButtonStickXL.Text = "button4";
			this.ButtonStickXL.UseVisualStyleBackColor = true;
			this.ButtonStickXL.Visible = false;
			this.ButtonStickXL.MouseLeave += this.Button_HoverLeave;
			this.ButtonStickXL.MouseHover += this.Button_Hover;
			this.ButtonStickYU.Location = new Point(72, 224);
			this.ButtonStickYU.Name = "ButtonStickYU";
			this.ButtonStickYU.Size = new Size(73, 36);
			this.ButtonStickYU.TabIndex = 13;
			this.ButtonStickYU.Text = "Z Rotationri Z Rotation";
			this.ButtonStickYU.UseVisualStyleBackColor = true;
			this.ButtonStickYU.Visible = false;
			this.ButtonStickYU.MouseLeave += this.Button_HoverLeave;
			this.ButtonStickYU.Click += this.ButtonStickLX_Click;
			this.ButtonStickYU.MouseHover += this.Button_Hover;
			this.ButtonStickXR.Location = new Point(119, 270);
			this.ButtonStickXR.Name = "ButtonStickXR";
			this.ButtonStickXR.Size = new Size(73, 36);
			this.ButtonStickXR.TabIndex = 14;
			this.ButtonStickXR.Text = "button2";
			this.ButtonStickXR.UseVisualStyleBackColor = true;
			this.ButtonStickXR.Visible = false;
			this.ButtonStickXR.MouseLeave += this.Button_HoverLeave;
			this.ButtonStickXR.MouseHover += this.Button_Hover;
			this.ResetDefaultButton.Location = new Point(377, 391);
			this.ResetDefaultButton.Name = "ResetDefaultButton";
			this.ResetDefaultButton.Size = new Size(91, 41);
			this.ResetDefaultButton.TabIndex = 17;
			this.ResetDefaultButton.Text = "Reset to Default";
			this.ResetDefaultButton.UseVisualStyleBackColor = true;
			this.ResetDefaultButton.Visible = false;
			this.ResetDefaultButton.Click += this.ResetDefaultButton_Click;
			this.pictureBox1.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new Point(6, 55);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(834, 403);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 18;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Instructions_label.BackColor = SystemColors.AppWorkspace;
			this.Instructions_label.Location = new Point(12, 435);
			this.Instructions_label.Name = "Instructions_label";
			this.Instructions_label.Size = new Size(823, 21);
			this.Instructions_label.TabIndex = 19;
			this.Instructions_label.Text = "To change a button mapping hover the mouse pointer over a button and then press the key / button on the selected input device that you wish to assign,";
			this.Instructions_label.TextAlign = ContentAlignment.MiddleCenter;
			this.pictureBox2.Image = (Image)componentResourceManager.GetObject("pictureBox2.Image");
			this.pictureBox2.Location = new Point(6, 55);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new Size(834, 403);
			this.pictureBox2.TabIndex = 20;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.StartButtonInstructions_Label.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.StartButtonInstructions_Label.Location = new Point(92, 4);
			this.StartButtonInstructions_Label.Name = "StartButtonInstructions_Label";
			this.StartButtonInstructions_Label.Size = new Size(670, 21);
			this.StartButtonInstructions_Label.TabIndex = 21;
			this.StartButtonInstructions_Label.Text = "label1";
			this.StartButtonInstructions_Label.TextAlign = ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.StartButtonInstructions_Label);
			base.Controls.Add(this.Instructions_label);
			base.Controls.Add(this.ResetDefaultButton);
			base.Controls.Add(this.ButtonStickYD);
			base.Controls.Add(this.ButtonStickXL);
			base.Controls.Add(this.ButtonStickXR);
			base.Controls.Add(this.ButtonStickYU);
			base.Controls.Add(this.ButtonLT);
			base.Controls.Add(this.ButtonRT);
			base.Controls.Add(this.ButtonRB);
			base.Controls.Add(this.ButtonLB);
			base.Controls.Add(this.ButtonBack);
			base.Controls.Add(this.ButtonStart);
			base.Controls.Add(this.ButtonY);
			base.Controls.Add(this.ButtonX);
			base.Controls.Add(this.InputTypeLabel);
			base.Controls.Add(this.InputType);
			base.Controls.Add(this.ButtonB);
			base.Controls.Add(this.ButtonA);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.pictureBox2);
			base.Name = "InputConfiguration";
			base.Size = new Size(846, 460);
			base.Load += this.InputConfiguration_Load;
			((ISupportInitialize)this.pictureBox1).EndInit();
			((ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public Timer InputUpdateTimer;

		public Timer ResetTimer;

		private Button ActiveButton;

		private List<PadInfo> mPadInfoList;

		private List<PadInfo> mGuidPadInfoList;

		private List<ButtonConfig> mButtonList;

		private List<ButtonConfig> mMovementButtonList;

		private List<ButtonConfig> mMovementButtonPairX;

		private List<ButtonConfig> mMovementButtonPairY;

		private bool bRefreshButtons;

		public bool Found360Pad;

		private byte MovementInputType;

		private IContainer components;

		private Button ButtonA;

		private Button ButtonB;

		private ComboBox InputType;

		private Label InputTypeLabel;

		private Button ButtonX;

		private Button ButtonY;

		private Button ButtonRB;

		private Button ButtonLB;

		private Button ButtonBack;

		private Button ButtonStart;

		private Button ButtonLT;

		private Button ButtonRT;

		private Button ButtonStickYD;

		private Button ButtonStickXL;

		private Button ButtonStickYU;

		private Button ButtonStickXR;

		private Button ResetDefaultButton;

		private PictureBox pictureBox1;

		private Label Instructions_label;

		private PictureBox pictureBox2;

		private Label StartButtonInstructions_Label;
	}
}
