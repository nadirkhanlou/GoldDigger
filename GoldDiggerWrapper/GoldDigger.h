#pragma once
#include "ManagedObject.h"
#include "../GoldDiggerCore/Controller.h"

using namespace GoldDiggerWrapper;
using namespace GoldDiggerCore;

namespace GoldDigger {

	public ref class GoldDiggerSolver : ManagedObject<Controller>
	{
	private:
	public:
		GoldDiggerSolver(String^ path);
	};
} // GoldDigger