#pragma once
#include "Map.h"
#include "Agent.h"

using namespace GoldDiggerMap;
using namespace GoldDiggerAgent;

namespace GoldDiggerController {

	class Controller {
	private:
		Map _map;
		GoldDiggerAgent::Agent _agent;
	public:
		Controller(const char* path);
	};

} //GoldDiggerSolver