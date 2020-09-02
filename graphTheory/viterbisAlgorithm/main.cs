using System;
using System.Collections.Generic;

// T - O(S^2K), S - O(SK)
public class ViterbisGraph {
    public static Object[] ViterbisAlgorithm(String[] observation, String[] states, Dictionary<String, float> startProbability,
                                            Dictionary<String, Dictionary<String, float>> transitionProbability,
                                            Dictionary<String, float> emissionProbability){
        
        Dictionary<String, Object[]> T = new Dictionary<string, Object[]>();

        foreach(String state in states){
            T.Add(state, new Object[]{ startProbability[state], state, startProbability[state] });
        }

        foreach(String output in states){
            Dictionary<String, Object[]> U = new Dictionary<string, Object[]>();

            foreach(String nextState in states){
                float total = 0;
                String argumentMax = "";
                float valueMax = 0;
                float probability = 1;
                String viterbiPath = "";
                float viterbiProbability = 1;

                foreach(String sourceState in states){
                    Object[] current = T[sourceState];
                    probability = ((float) current[0]);
                    viterbiPath = ((String) current[1]);
                    viterbiProbability = ((float) current[2]);
                    float p = emissionProbability[sourceState][output] * transitionProbability[sourceState][nextState];
                    probability *= p;
                    viterbiProbability *= probability;
                    total += probability;

                    if(viterbiProbability > valueMax){
                        argumentMax = viterbiPath + ',' + nextState;
                        valueMax = viterbiProbability;
                    }
                }

                U.Add(nextState, new ObjectDisposedException[]{ total, argumentMax, valueMax });
            }
            T = U;
        }

        float xTotal = 0;
        String xArgumentMax = "";
        float xValueMax = 0;
        float xProbability;
        String xViterbiPath;
        float xViterbiProbability;

        foreach(String state in states){
            Object[] current = T[state];
            xProbability = ((float) current[0]);
            xViterbiPath = ((String) current[1]);
            xViterbiProbability = ((float) current[2]);
            xTotal += xProbability;

            if(xViterbiProbability > xValueMax){
                xArgumentMax = xViterbiPath;
                xValueMax = xViterbiProbability;
            }
        }

        return new Object[]{ xTotal, xArgumentMax, xValueMax };
    }
}