using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
	internal class CharacterCard
	{
		public bool gamestarted { get; set; } = true;
		public string prompt { get; set; } = "";
		public string memory { get; set; } = "";
		public string authorsnote { get; set; } = "";
		public string anotetemplate { get; set; } = "[Author's note: <|>]";

		/// <summary>
		/// template : /n{name}:{text}
		/// </summary>
		public List<object> actions { get; set; } = new List<object>();
		public object actions_metadata { get; set; } = new { };
		public List<object> worldinfo { get; set; } = new List<object>();
		public object wifolders_d { get; set; } = new { };
		public object wifolders_l { get; set; } = new { };
		public string extrastopseq { get; set; } = "";
		public Savedsettings savedsettings { get; set; } = new Savedsettings();

		public CharacterCard() { }
	}

	public class Savedsettings
	{
		public string my_api_key { get; set; } = "0000000000";
		public string home_cluster { get; set; } = "https://horde.koboldai.net";
		// ...rest of properties initialized to their default values...
		public bool autoscroll { get; set; } = true;
		public bool trimsentences { get; set; } = true;
		public bool trimwhitespace { get; set; } = false;
		public int opmode { get; set; } = 3;
		public bool adventure_is_action { get; set; } = false;
		public bool adventure_context_mod { get; set; } = true;
		public string chatname { get; set; } = "You";
		public string chatopponent { get; set; } = "KoboldAI";
		public string instruct_starttag { get; set; } = "\\n### Instruction:\\n";
		public string instruct_endtag { get; set; } = "\\n### Response:\\n";
		public bool instruct_has_markdown { get; set; } = false;
		public bool persist_session { get; set; } = true;
		public int speech_synth { get; set; } = 0;
		public bool beep_on { get; set; } = false;
		public string image_styles { get; set; } = "";
		public string generate_images { get; set; } = "";
		public bool img_autogen { get; set; } = false;
		public bool img_allownsfw { get; set; } = true;
		public bool save_images { get; set; } = true;
		public bool case_sensitive_wi { get; set; } = false;
		public int last_selected_preset { get; set; } = 0;
		public bool enhanced_chat_ui { get; set; } = true;
		public bool enhanced_instruct_ui { get; set; } = false;
		public bool multiline_replies { get; set; } = false;
		public bool allow_continue_chat { get; set; } = false;
		public int idle_responses { get; set; } = 0;
		public int idle_duration { get; set; } = 60;
		public bool export_settings { get; set; } = true;
		public bool invert_colors { get; set; } = false;
		public int max_context_length { get; set; } = 4096;
		public int max_length { get; set; } = 100;
		public bool auto_ctxlen { get; set; } = true;
		public bool auto_genamt { get; set; } = true;
		public double rep_pen { get; set; } = 1.1;
		public int rep_pen_range { get; set; } = 320;
		public double rep_pen_slope { get; set; } = 0.7;
		public double temperature { get; set; } = 0.7;
		public double top_p { get; set; } = 0.92;
		public int top_k { get; set; } = 0;
		public int top_a { get; set; } = 0;
		public int typ_s { get; set; } = 1;
		public int tfs_s { get; set; } = 1;
		public List<int> sampler_order { get; set; } = new List<int> { 6, 0, 1, 3, 4, 2, 5 };

		public Savedsettings() { }

	}
}
