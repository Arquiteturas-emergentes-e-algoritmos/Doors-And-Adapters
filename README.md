# Portas e adaptadores ou Hexagonal

Assim como a arquitetura limpa, a Hexagonal surge como um modo de desenvolver uma aplicação agnostica de tecnologias, sendo assim, isolada do mundo externo. </br>
Nesta arquitetura, a lógica de aplicação fica toda encapsulada dentro do núcleo, e para a informação passar por ele, a mesma deve ser submetida a duas estruturas principais que ficam nas fronteiras da arquitetura:

- As portas, que são protocolos e interfaces que definem como a aplicação funciona e quais dados ela precisa possibilitando a ligação da mesma com o mundo externo. Podemos ter duas classes de portas: as principais, ou adaptadores condutores nas quais conduzem o usuário a uma ação, e as secundárias, ou adaptadores conduzidos, nas quais levam o usuário a uma ação. Em diagramas, elas aparecem à esquerda e a direita respectivamente.</br>
 
- Os adaptadores, estão presentes em cada porta e para cada elemento do mundo externo.</br>
 
A arquitetura é descrita na imagem abaixo :

<< imagem >>

Ao submeter a aplicação proposta à tal arquitetura e posteriormente ao Sonar, foi observado, uma duplicação de código zerada e alguns problemas de manutenabilidade, nos quais foram posteriormente solucionados, com exceção de uma, em que não foi possível solucionar devido a regras de linguagem.</br>
Algo que chamou muito a atenção foi a baixa quantidade de linhas em comparação com a arquitetura limpa além da facilidade em empregar novas features e testa-las. 
