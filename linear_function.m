function [] = linear_function ()

clc
clear all

n = 10;
z = 1/(n-1);

B = zeros(n,1);
B(1) = 1;
A1 = zeros(n,1);
A1(1:n) = -1+(10*z);
A2 = ones(n,1);
A = [A1 A2];
C = spdiags(A,[-1 0],n,n);
J = C\B;

plot(z,J)


end