#pragma once

using namespace System::Runtime::InteropServices;
using namespace System;

namespace GoldDiggerWrapper {
	
	class Conversion {
	public:
		static const char* string_to_char_array(String^ string)
		{
			const char* str = (const char*)(Marshal::StringToHGlobalAnsi(string)).ToPointer();
			return str;
		}
		static String^ char_array_to_string(const char* charArray) {
			String^ str = Marshal::PtrToStringAnsi((IntPtr)(char*)charArray);
			return str;
		}
	};
} // GoldDiggerWrapper