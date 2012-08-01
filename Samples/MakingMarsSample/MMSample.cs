
        private void Pause()
        {
            paused = !paused;
            if (paused)
            {
                MakingMarsEngine.GUI.Control.HilightColor = Color.Orange;
                EngineComponent.Storage.Load("PauseMenu");
                sounds.RadioMusic.Pause();
                rover.PauseRover(true);
                pauseMenuControl = new MakingMarsEngine.GUI.ControlCollection(EngineComponent.Storage.GetValueAsString("Layout"), EngineComponent.Storage.GetValueAsString("Values"));

                ((Sliderbar)pauseMenuControl["pBMGSOUND"]).Move((float)Math.Round((CurrentDBProfile.DBPatient.BGMVolume * 100 - ((Sliderbar)pauseMenuControl["pBMGSOUND"]).Value) / 5, 0));
                ((Sliderbar)pauseMenuControl["pEFXSOUND"]).Move((float)Math.Round((CurrentDBProfile.DBPatient.SFXVolume * 100 - ((Sliderbar)pauseMenuControl["pEFXSOUND"]).Value) / 5, 0));

                (pauseMenuControl["pBMGSOUND"] as MakingMarsEngine.GUI.Sliderbar).OnSliderChanged += playBGMSoundOnSlide;
                (pauseMenuControl["pEFXSOUND"] as MakingMarsEngine.GUI.Sliderbar).OnSliderChanged += playSFXSoundOnSlide;
                (pauseMenuControl["pBMGSOUND"] as MakingMarsEngine.GUI.Sliderbar).OnSliderChanged += delegate(float val) { rover._BMGSOUND = (pauseMenuControl["pBMGSOUND"] as MakingMarsEngine.GUI.Sliderbar).Value / 100; rover.SetVolume(); };
                (pauseMenuControl["pEFXSOUND"] as MakingMarsEngine.GUI.Sliderbar).OnSliderChanged += delegate(float val) { rover._EFXSOUND = (pauseMenuControl["pEFXSOUND"] as MakingMarsEngine.GUI.Sliderbar).Value / 100; };
                (pauseMenuControl["Resume"] as MakingMarsEngine.GUI.Button).OnUse += new Action(Pause);
                (pauseMenuControl["Exit"] as MakingMarsEngine.GUI.Button).OnUse += delegate() 
                { 
                    EngineComponent.Input.ResetButtons(); 
                    EngineComponent.Input.ResetKeys(); 
                    ParentGame.RunSubgame(typeof(MakingMars.MainMenu)); 
                };
                pauseMenuControl.setLayer(1f);
                EngineComponent.Manager3D.Enabled = false;
                Hud.Enabled = false;
                pauseBackground.Visible = true;
                rover.StopEngine();
                if(dust != null)
                    dust.Visible = false;
                GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
                if (OnPause != null)
                    OnPause();
            }
            else
            {
                rover._BMGSOUND = CurrentDBProfile.DBPatient.BGMVolume;
                rover._EFXSOUND = CurrentDBProfile.DBPatient.SFXVolume;
                sounds.RadioMusic.Resume();
                rover.PauseRover(false);
                pauseMenuControl.Dispose();
                EngineComponent.Input.GetKey(Keys.Left).ResetEvents();
                EngineComponent.Input.GetKey(Keys.Right).ResetEvents();
                Hud.Enabled = true; 
                EngineComponent.Manager3D.Enabled = true;
                pauseBackground.Visible = false;
                MMDatabase.SaveChanges();
                if (dust != null)
                    dust.Visible = true;
                rover.PlayEngine();
                MakingMarsEngine.GUI.Control.HilightColor = Color.Cyan;
                if (OnUnpause != null)
                    OnUnpause();
            }
        }
       
        public void playSFXSoundOnSlide(float aFloat)
        {
            if (HasSpeakers)
            {
                SoundEngine.InternalSoundEngine.GameAudioEngine.GetCategory("PauseSound").SetVolume((aFloat / 100));
                CurrentDBProfile.DBPatient.SFXVolume = (aFloat / 100);
                pauseSound.Play();
            }
        }

        public void playBGMSoundOnSlide(float aFloat)
        {
            if (HasSpeakers)
            {
                SoundEngine.InternalSoundEngine.GameAudioEngine.GetCategory("PauseSound").SetVolume((aFloat / 100));
                CurrentDBProfile.DBPatient.BGMVolume = (aFloat / 100);
                pauseSound.Play();
            }
        }

