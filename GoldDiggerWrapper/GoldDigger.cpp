#include "GoldDigger.h"
#include "Conversion.h"

namespace GoldDigger {
	GoldDiggerSolver::GoldDiggerSolver(String^ path) :ManagedObject<Controller>(new Controller(Conversion::string_to_char_array(path))) {
		srand(time(0));
	}

	array<int>^ GoldDiggerSolver::ValueIteration(double gamma) {
		AgentAction* actions = m_Instance->ValueIteration(gamma);
		array<int>^ result = gcnew array<int>(m_Instance->Size().first * m_Instance->Size().second);
		for (int i = 0; i < result->Length; ++i) {
			result[i] = (int)actions[i];
		}
		return result;
	}

	array<int>^ GoldDiggerSolver::PolicyIteration(double gamma) {
		AgentAction* actions = m_Instance->PolicyIteration(gamma);
		array<int>^ result = gcnew array<int>(m_Instance->Size().first * m_Instance->Size().second);
		for (int i = 0; i < result->Length; ++i) {
			result[i] = (int)actions[i];
		}
		return result;
	}

	int GoldDiggerSolver::QLearningAct(double gamma)
	{
		AgentAction action = m_Instance->QLearningAct(gamma);
		return action;
	}

	int GoldDiggerSolver::AgentRandomPosition()
	{
		return m_Instance->AgentRandomPosition();
	}

	array<array<double>^>^ GoldDiggerSolver::GetQTable()
	{
		array<array<double>^>^ retVal = gcnew array<array<double>^> (m_Instance->Size().first * m_Instance->Size().second);
		double** qTable = m_Instance->GetQTable();
		for (int i = 0; i < retVal->Length; ++i) {
			retVal[i] = gcnew array<double>(4);
			retVal[i][0] = qTable[i][0];
			retVal[i][1] = qTable[i][1];
			retVal[i][2] = qTable[i][2];
			retVal[i][3] = qTable[i][3];
		}
		return retVal;
	}

	void GoldDiggerSolver::PrintQTable()
	{
		m_Instance->PrintQTable();
	}

} // GoldDigger
