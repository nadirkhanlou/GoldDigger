#pragma once
#include"ManagedObject.h"

using namespace GoldDiggerWrapper;

namespace GoldDigger {

	struct solver {
		solver() {

		}
	};

	public ref class GoldDiggerSolver : ManagedObject<solver>
	{
	private:
	public:
		GoldDiggerSolver();
	};
} // GoldDigger