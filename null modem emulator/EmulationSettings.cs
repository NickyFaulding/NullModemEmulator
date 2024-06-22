namespace com_emulator
{
    public class EmulationSettings
    {
        /// <summary>
        /// Enable baud rate emulation in the direction to the paired port (disabled by default)
        /// </summary>
        public bool EmulateBaudRate { get; set; } = false;

        /// <summary>
        /// Enable buffer overrun (disabled by default)
        /// </summary>
        public bool EmulateOverrun { get; set; } = false;

        /// <summary>
        /// Probability in range 0-0.99999999 of error per character frame in the direction to the paired port (0 by default)
        /// </summary>
        public double EmulateNoise { get; set; } = 0;

        /// <summary>
        /// Get the current settings in a com0com argument format
        /// </summary>
        /// <returns></returns>
        public string[] GetSettings()
        {
            var settings = new string[]
            {
                $"EmuBR={(EmulateBaudRate?"yes":"no")}",
                $"EmuOverrun={(EmulateOverrun?"yes":"no")}",
                $"EmuNoise={(EmulateNoise)}",
            };

            return settings;
        } 
    }
}
