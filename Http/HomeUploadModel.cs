namespace FileThing.Http {

	using Microsoft.AspNet.Http;
	using System.ComponentModel.DataAnnotations;

	public class HomeUploadModel {

		[Required]
		public IFormFile Thing { get; set; }

		[Required]
		[MinLength(3)]
		public string Name { get; set; }

	}

}
