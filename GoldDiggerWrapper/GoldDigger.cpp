#include "GoldDigger.h"
#include "Conversion.h"

namespace GoldDigger {
	GoldDiggerSolver::GoldDiggerSolver(String^ path) :ManagedObject<Controller>(new Controller(Conversion::string_to_char_array(path)))
	{

	}
} // GoldDigger
