import math as math

def cost(f,d, hb, hm, G): 
    F = 46.3+33.9*math.log10(f)-13.82*math.log10(hb)
    B = 44.9-6.55*math.log10(hb)
    Ba = B*math.log10(d)
    C = (1.1*math.log10(f) - 0.7)*hm - 1.56*math.log10(f)+0.8
    print("F: " + str(F))
    print("B: " + str(B))
    print("C: " + str(C))
    res = F + Ba - C + G
    return res

# Calculate total gain

prx = cost(1800, 1,52, 1.5, 0 )
print(prx)