namespace Saar.FFmpeg.CSharp {
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