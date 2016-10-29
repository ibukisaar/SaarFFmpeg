namespace Saar.FFmpeg.Enumerates {
	public enum AVIODirEntryType : int {
		Unknown,
		BlockDevice,
		CharacterDevice,
		Directory,
		NamedPipe,
		SymbolicLink,
		Socket,
		File,
		Server,
		Share,
		Workgroup,
	}
}