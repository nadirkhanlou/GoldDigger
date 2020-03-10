#include "GoldDigger.h"
#include "Conversion.h"

namespace GoldDigger {
	GoldDiggerSolver::GoldDiggerSolver(String^ path) :ManagedObject<Controller>(new Controller(Conversion::string_to_char_array(path))) {
	}

	array<int>^ GoldDiggerSolver::ValueIteration() {
		AgentAction* actions = m_Instance->ValueIteration();
		array<int>^ result = gcnew array<int>(m_Instance->Size().first * m_Instance->Size().second);
		for (int i = 0; i < result->Length; ++i) {
			result[i] = actions[i];
		}
		return result;
	}

	array<int>^ GoldDiggerSolver::PolicyIteration() {
		AgentAction* actions = m_Instance->PolicyIteration();
		array<int>^ result = gcnew array<int>(m_Instance->Size().first * m_Instance->Size().second);
		for (int i = 0; i < result->Length; ++i) {
			result[i] = actions[i];
		}
		return result;
	}

} // GoldDigger
