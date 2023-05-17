#include <string>
#include <vector>

using namespace std;

std::vector<std::string> solution(const std::string& s)
{
    vector<string> res;
    
    if (s.empty())
    {
        return res;
    }
    for (int i = 0; i < s.size() - 1; i += 2)
    {
        res.push_back(s.substr(i, 2));
    }
    if (s.size() % 2 != 0)
    {
        res.push_back(s.substr(s.size() - 1, 1) + "_");
    }
    return res;
}