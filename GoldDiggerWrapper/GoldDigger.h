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
		array<int>^ ValueIteration(double gamma);
		array<int>^ PolicyIteration(double gamma);
		int QLearningAct(double gamma);
		int AgentRandomPosition();
		array<array<double>^>^ GetQTable();
		void PrintQTable();
	};
} // GoldDigger