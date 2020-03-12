#pragma once
#include "ManagedObject.h"
#include "../GoldDiggerCore/Controller.h"
//#include "../GoldDiggerGUI/AgentAction.cs"

using namespace GoldDiggerWrapper;
using namespace GoldDiggerCore;

namespace GoldDigger {

	public ref class GoldDiggerSolver : ManagedObject<Controller>
	{
	private:
	public:
		GoldDiggerSolver(String^ path);
		array<int>^ ValueIteration();
		array<int>^ PolicyIteration();
		int QLearningAct();
		int AgentRandomPosition();
	};
} // GoldDigger