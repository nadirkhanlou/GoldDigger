#pragma once

#include <vector>
#include <fstream>
#include <utility>
#include <assert.h>
#include <iostream>

#include "../GoldDiggerGUI/AgentAction.cs"

#define GOAL_SCORE 1

namespace GoldDiggerCore {

	struct Block {
		bool down, left, up, right;		// Determines wether each action is possible in the block
		bool gold;						// Determines whether the block contains gold

		Block()
			: up(1), right(1), down(1), left(1), gold(0)
		{ }

		Block(bool u, bool r, bool d, bool l)
			: up(u), right(r), down(d), left(l), gold(0)
		{ }
	};

	class Map {
		friend struct Options;
	private:
		Block* _map;
		unsigned int _n, _m;
		unsigned int _startPos;
		bool* _goldAccessPartition;


	public:
		Map(const char* path);
		Map(const Map& other);
		Map(Map&& other);
		Map& operator=(const Map& other);
		Map& operator=(Map&& other);
		~Map();

		Block Sense(unsigned int pos);
		unsigned int NextPosition(unsigned int pos, AgentAction action);
		int ActionReward(unsigned int pos, AgentAction action);
		void MarkAsAccessible(unsigned int pos);
		bool IsAccessible(unsigned int pos);
	};


} // namespace GoldDiggerCore
